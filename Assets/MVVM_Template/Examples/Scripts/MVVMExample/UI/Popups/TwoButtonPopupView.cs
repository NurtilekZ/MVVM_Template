using MVVM.Core.Views;
using UnityEngine;
using UnityEngine.UI;

namespace MVVMExample.UI.Popups
{
    public class TwoButtonPopupView : BasePopupView
    {
        [SerializeField] private Button _cancelButton;
        
        private TwoButtonPopupViewModel _twoButtonViewModel;

        protected override void Bind()
        {
            base.Bind();
            _twoButtonViewModel = (TwoButtonPopupViewModel) _viewModel;
            _cancelButton.onClick.AddListener(_twoButtonViewModel.Cancel);
        }

        protected override void Unbind()
        {
            base.Unbind();
            _cancelButton.onClick.RemoveListener(_twoButtonViewModel.Cancel);
        }
    }
}