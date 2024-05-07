using System;
using MVVM.Core.ViewModels;
using MVVMExample.Infrastructure.AssetManagement;

namespace MVVMExample.UI.Popups
{
    public class TwoButtonPopupViewModel : BasePopupViewModel
    {
        private readonly Action _cancelAction;
        public override string AssetPath => AssetPaths.OneButtonPopup;

        public TwoButtonPopupViewModel(string titleText, Action confirmAction, Action cancelAction = null) : base(titleText, confirmAction)
        {
            if (cancelAction != null) 
                _cancelAction = cancelAction;
        }

        public override void Confirm()
        {
            _confirmAction?.Invoke();
            _uiService.Close<TwoButtonPopupViewModel>();
        }

        public void Cancel()
        {
            _cancelAction?.Invoke();
            _uiService.Close<TwoButtonPopupViewModel>();
        }
    }
}