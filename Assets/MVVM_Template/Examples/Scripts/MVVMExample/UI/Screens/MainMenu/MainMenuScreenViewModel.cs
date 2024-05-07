using MVVM.Core.ViewModels;
using MVVMExample.Infrastructure.AssetManagement;
using MVVMExample.Infrastructure.Bootstrap;
using MVVMExample.Infrastructure.Services.SceneLoading;
using MVVMExample.UI.Popups;
using UnityEngine;

namespace MVVMExample.UI.Screens.MainMenu
{
    public class MainMenuScreenViewModel : BaseViewModel
    {
        private const string GameSceneName = "GameScene";
        public override string AssetPath { get; protected set; } = AssetPaths.MainMenuScreen;

        private readonly ISceneLoadingService _sceneLoadingService = ServiceLocator.GetService<ISceneLoadingService>();

        public async void PlayGame()
        {
            await _sceneLoadingService.LoadSceneAsync(GameSceneName);
        }

        public void ExitGame()
        {
            _uiService.Open(new TwoButtonPopupViewModel(
                "Are you sure to exit Game?",
                ConfirmAction));
        }

        private void ConfirmAction() => 
            Application.Quit();
    }
}