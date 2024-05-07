using System;
using MVVM.Core.Interfaces;
using MVVMExample.Infrastructure.AssetManagement;
using MVVMExample.Infrastructure.Bootstrap;
using MVVMExample.Infrastructure.Services.UI;

namespace MVVM.Core.ViewModels
{
    public class BasePopupViewModel : IPopupViewModel
    {
        public virtual bool IsInSceneCanvas => true;
        public virtual string AssetPath => AssetPaths.OneButtonPopup;
        public IUIService _uiService { get; }

        public string TitleText { get; }

        protected readonly Action _confirmAction;
        
        public BasePopupViewModel(string titleText, Action confirmAction)
        {
            TitleText = titleText;
            _confirmAction = confirmAction;
            _uiService = ServiceLocator.GetService<IUIService>();
        }

        public virtual void Confirm()
        {
            _confirmAction?.Invoke();
            _uiService.Close<BasePopupViewModel>();
        }

        public virtual void Dispose()
        {
            
        }
    }
}