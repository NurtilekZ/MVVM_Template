using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVVM.Core.Interfaces;
using MVVMExample.Infrastructure.Factories;
using UnityEngine;

namespace MVVMExample.Infrastructure.Services.UI
{
    public class UIService : IUIService
    {
        private readonly IUIFactory _factory;
        private readonly Dictionary<Type, IView> _rootOpenViews = new();
        private readonly Dictionary<Type, IView> _sceneOpenViews = new();
        
        public UIService(IUIFactory factory)
        {
            _factory = factory;
        }

        public async Task<IView> Open<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            var targetViews = _sceneOpenViews;
            if (!viewModel.IsInSceneCanvas) 
                targetViews = _rootOpenViews;
            
            if (targetViews.TryGetValue(typeof(TViewModel), out var cachedView))
            {
                if (cachedView != null)
                {
                    cachedView.ShowAndBind(viewModel);
                    return cachedView;
                }
            }

            var newView = await _factory.GetOrCreateView(viewModel);
            
            newView.ShowAndBind(viewModel);
            
            targetViews[typeof(TViewModel)] = newView;
            Debug.Log($"[UI Service] Open {typeof(TViewModel).Name}");

            return newView;
        }

        public void Close<TViewModel>()
        {
            if (_rootOpenViews.TryGetValue(typeof(TViewModel), out var rootView))
            {
                if (!rootView.IsShown) return;
                rootView.HideAndUnbind();
                Debug.Log($"[UI Service] Close {typeof(TViewModel).Name} in Root Canvas");
            }
            else if (_sceneOpenViews.TryGetValue(typeof(TViewModel), out var sceneView))
            {
                if (!sceneView.IsShown) return;
                sceneView.HideAndUnbind();
                Debug.Log($"[UI Service] Close {typeof(TViewModel).Name} in Scene Canvas");
            }
        }

        public void CleanUpSceneViews()
        {
            foreach (var sceneView in _sceneOpenViews) 
                sceneView.Value.HideAndUnbind();
            
            _sceneOpenViews.Clear();
        }

        public void Dispose()
        {
            foreach (var openView in _rootOpenViews) 
                openView.Value.Dispose();
        }
    }
}