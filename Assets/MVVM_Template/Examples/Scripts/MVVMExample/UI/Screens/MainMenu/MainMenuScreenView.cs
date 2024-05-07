using MVVM.Core.Views;
using UnityEngine;
using UnityEngine.UI;

namespace MVVMExample.UI.Screens.MainMenu
{
    public class MainMenuScreenView : BaseView<MainMenuScreenViewModel>
    {
        [SerializeField] private Button _play;
        [SerializeField] private Button _exitGame;
        
        protected override void Bind()
        {
            _play.onClick.AddListener(_viewModel.PlayGame);
            _exitGame.onClick.AddListener(_viewModel.ExitGame);
        }

        protected override void Unbind()
        {
            _play.onClick.RemoveListener(_viewModel.PlayGame);
            _exitGame.onClick.RemoveListener(_viewModel.ExitGame);
        }
    }
}