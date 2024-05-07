using MVVM.Core.Views;
using UnityEngine;
using UnityEngine.UI;

namespace MVVMExample.UI.Screens.Pause
{
    public class PauseScreenView : BaseView<PauseScreenViewModel>
    {
        [SerializeField] private Button _continue;
        [SerializeField] private Button _exitToMenu;
        [SerializeField] private Button _exitGame;
        
        protected override void Bind()
        {
            _continue.onClick.AddListener(_viewModel.ContinueGame);
            _exitToMenu.onClick.AddListener(_viewModel.TryExitToMenu);
            _exitGame.onClick.AddListener(_viewModel.TryExitGame);
        }

        protected override void Unbind()
        {
            _continue.onClick.RemoveListener(_viewModel.ContinueGame);
            _exitToMenu.onClick.RemoveListener(_viewModel.TryExitToMenu);
            _exitGame.onClick.RemoveListener(_viewModel.TryExitGame);
        }
    }
}