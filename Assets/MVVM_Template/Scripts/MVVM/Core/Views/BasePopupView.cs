using MVVM.Core.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.Core.Views
{
    public class BasePopupView : BaseView<BasePopupViewModel>
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private Button _confirmButton;

        protected override void Bind()
        {
            _titleText.text = _viewModel.TitleText;
            _confirmButton.onClick.AddListener(_viewModel.Confirm);
        }

        protected override void Unbind()
        {
            _confirmButton.onClick.RemoveListener(_viewModel.Confirm);
        }
    }
}