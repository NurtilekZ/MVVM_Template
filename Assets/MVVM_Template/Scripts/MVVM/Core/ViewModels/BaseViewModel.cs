using System;
using System.Collections.Generic;
using MVVM.Core.Interfaces;
using MVVMExample.Infrastructure.Bootstrap;
using MVVMExample.Infrastructure.Services.UI;

namespace MVVM.Core.ViewModels
{
    public abstract class BaseViewModel : IViewModel
    {
        public virtual bool IsInSceneCanvas { get; protected set; } = true;
        public abstract string AssetPath { get; protected set; }
        public IUIService _uiService { get; }

        protected readonly List<IDisposable> _disposables = new();

        protected BaseViewModel()
        {
            _uiService = ServiceLocator.GetService<IUIService>();
        }

        public virtual void Dispose()
        {
            foreach (var disposable in _disposables)
                disposable?.Dispose();
        }
    }
}