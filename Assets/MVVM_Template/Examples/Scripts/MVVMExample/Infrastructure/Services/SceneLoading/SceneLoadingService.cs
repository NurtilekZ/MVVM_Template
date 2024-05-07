using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using MVVMExample.Infrastructure.Factories;
using MVVMExample.Infrastructure.Services.UI;
using MVVMExample.UI.Screens.Loading;
using UnityEngine.SceneManagement;

namespace MVVMExample.Infrastructure.Services.SceneLoading
{
    public class SceneLoadingService : ISceneLoadingService
    {
        public event Action<Scene, LoadSceneMode> sceneLoaded;
        public event Action<Scene, Scene> activeSceneChanged;

        private IUIFactory _uiFactory;
        private IUIService _uiService;

        public SceneLoadingService(IUIService uiService, IUIFactory uiFactory)
        {
            _uiService = uiService;
            _uiFactory = uiFactory;
            
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private async void OnSceneLoaded(Scene arg0, LoadSceneMode arg1) => 
            sceneLoaded?.Invoke(arg0, arg1);

        private async void OnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            await _uiFactory.CreateSceneRootCanvas();
            activeSceneChanged?.Invoke(arg0, arg1);
            _uiService.Close<LoadingScreenViewModel>();
        }

        public void LoadScene(int sceneIndex)
        {
            _uiService.Open(new LoadingScreenViewModel());
            _uiService.CleanUpSceneViews();
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadScene(string sceneName)
        {
            _uiService.Open(new LoadingScreenViewModel());
            _uiService.CleanUpSceneViews();
            SceneManager.LoadScene(sceneName);
        }

        public async Task LoadSceneAsync(int sceneIndex)
        {
            await _uiService.Open(new LoadingScreenViewModel());
            _uiService.CleanUpSceneViews();
            await SceneManager.LoadSceneAsync(sceneIndex);
        }

        public async Task LoadSceneAsync(string sceneName)
        {
            await _uiService.Open(new LoadingScreenViewModel());
            _uiService.CleanUpSceneViews();
            await SceneManager.LoadSceneAsync(sceneName);
        }

        public void Dispose()
        {
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}