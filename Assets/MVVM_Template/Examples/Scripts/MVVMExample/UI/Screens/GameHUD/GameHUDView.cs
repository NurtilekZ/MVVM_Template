using MVVM.Core.Views;
using MVVMExample.UI.Screens.GameHUD.SubViews;
using UnityEngine;

namespace MVVMExample.UI.Screens.GameHUD
{
    public class GameHUDView : BaseView<GameHUDViewModel>
    {
        [SerializeField] private HealthBarSubView _healthBarView;

        protected override void Bind()
        {
            _healthBarView.Show(_viewModel.PlayerHealthModel);
        }
        
        protected override void Unbind()
        {
            _healthBarView.Dispose();
        }
    }
}