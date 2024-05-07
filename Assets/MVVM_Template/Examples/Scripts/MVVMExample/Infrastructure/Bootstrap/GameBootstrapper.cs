using MVVMExample.Infrastructure.AssetManagement;
using MVVMExample.Infrastructure.Factories;
using MVVMExample.Infrastructure.Services.SceneLoading;
using MVVMExample.Infrastructure.Services.UI;
using UnityEngine;

namespace MVVMExample.Infrastructure.Bootstrap
{
    public class GameBootstrapper : MonoBehaviour
    {
        private const string MenuScene = "MenuScene";

        private void Awake()
        {
            Initialize();
            DontDestroyOnLoad(this);
        }

        private async void Initialize()
        {
            var assetProvider = new AssetProvider();
            var uiFactory = new UIFactory(assetProvider);
            var uiService = new UIService(uiFactory);
            var sceneLoadingService = new SceneLoadingService(uiService, uiFactory);
            
            ServiceLocator.AddService<IUIService>(uiService);
            ServiceLocator.AddService<ISceneLoadingService>(sceneLoadingService);
            
            await uiFactory.CreateRootCanvas();
            await sceneLoadingService.LoadSceneAsync(MenuScene);
        }
    }
}