using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVVM.Core.Interfaces;
using MVVMExample.Infrastructure.AssetManagement;
using MVVMExample.UI;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MVVMExample.Infrastructure.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetsProvider;

        private readonly Dictionary<Type, Object> _cachedViews = new();
        private RootCanvas _rootCanvas;
        private RootCanvas _sceneCanvas;

        private readonly string[] _uiAssetPaths = {
            AssetPaths.RootCanvas,
            
            AssetPaths.MainMenuScreen,
            AssetPaths.GameHUDScreen,
            AssetPaths.PauseScreen,
            AssetPaths.LoadingScreen,
            
            AssetPaths.OneButtonPopup,
            AssetPaths.TwoButtonPopup,
        };

        public UIFactory(IAssetProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public async Task WarmUp()
        {
            foreach (var assetPath in _uiAssetPaths)
            {
                await _assetsProvider.Load<GameObject>(assetPath);
            }
        }

        public void CleanUp()
        {
            foreach (var assetToUnload in _cachedViews.Values) 
                Resources.UnloadAsset(assetToUnload);;
            
            _cachedViews.Clear();
        }

        public async Task CreateRootCanvas()
        {
            if (_rootCanvas != null) return;

            var prefab = await _assetsProvider.Load<RootCanvas>(AssetPaths.RootCanvas);
            _rootCanvas = Object.Instantiate(prefab);
            _rootCanvas.GetComponent<Canvas>().sortingOrder = 1;
            Debug.Log($"[UI Factory] Create Root Canvas");
            Object.DontDestroyOnLoad(_rootCanvas.gameObject);
        }

        public async Task CreateSceneRootCanvas()
        {
            if (_sceneCanvas != null) return;
            
            var prefab = await _assetsProvider.Load<RootCanvas>(AssetPaths.RootCanvas);
            _sceneCanvas = Object.Instantiate(prefab);
            Debug.Log($"[UI Factory] Create Scene Canvas");
        }
        
        public async Task<IView> GetOrCreateView<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            var targetCanvas = viewModel.IsInSceneCanvas ? _sceneCanvas : _rootCanvas;
            var parentCanvas = viewModel switch
            {
                IPopupViewModel => targetCanvas.PopupsGroup.transform,
                IOverlayViewModel => targetCanvas.OverlaysGroup.transform,
                _ => targetCanvas.ScreensGroup.transform
            };
            
            var cachedAsset = GetView<TViewModel>();
            if (cachedAsset != null)
            {
                var cachedView = Object.Instantiate(cachedAsset, parentCanvas).GetComponent<IView>();
                return cachedView;
            }

            if (_sceneCanvas) 
                await CreateSceneRootCanvas();
            
            var prefab = await _assetsProvider.Load<GameObject>(viewModel.AssetPath);
            
            var newView = Object.Instantiate(prefab, parentCanvas).GetComponent<IView>();
            Debug.Log($"[UI Factory] Create {viewModel.GetType().Name} in {parentCanvas.name}");
            
            _cachedViews[typeof(TViewModel)] = prefab;

            return newView;
        }

        private Object GetView<TViewModel>() where TViewModel : IViewModel
        {
            return _cachedViews.GetValueOrDefault(typeof(TViewModel));
        }

        public void Dispose()
        {
            CleanUp();
        }
    }
}