using MVVM.Core.Interfaces;
using MVVM.Core.ViewModels;
using MVVMExample.Infrastructure.AssetManagement;
using MVVMExample.Infrastructure.Bootstrap;
using MVVMExample.Infrastructure.Services.SceneLoading;
using MVVMExample.UI.Popups;
using UnityEngine;

namespace MVVMExample.UI.Screens.Pause
{
    public class PauseScreenViewModel : BaseViewModel
    {
        private const string MenuScene = "MenuScene";
        public override string AssetPath { get; protected set; } = AssetPaths.PauseScreen;
        
        private IView _popupView;
        private readonly ISceneLoadingService _sceneLoadingService = ServiceLocator.GetService<ISceneLoadingService>();

        public void ContinueGame()
        {
            _uiService.Close<PauseScreenViewModel>();
        }

        public async void TryExitToMenu()
        {
            _popupView = await _uiService.Open(new TwoButtonPopupViewModel(
                "Are you Sure you want to exit to menu?",
                ConfirmExitToMenu));
        }

        public async void TryExitGame()
        {
            _popupView = await _uiService.Open(new TwoButtonPopupViewModel(
                "Are you sure to exit Game?",
                ConfirmExitGame));
        }
        
        private async void ConfirmExitToMenu()
        {
            await _sceneLoadingService.LoadSceneAsync(MenuScene);
        }

        private void ConfirmExitGame()
        {
            Application.Quit();
        }

        public override void Dispose()
        {
            base.Dispose();
            _popupView?.Dispose();
        }
    }
}