using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace MVVMExample.Infrastructure.Services.SceneLoading
{
    public interface ISceneLoadingService : IService
    {
        event Action<Scene, LoadSceneMode> sceneLoaded;
        event Action<Scene, Scene> activeSceneChanged;
        void LoadScene(int sceneIndex);
        void LoadScene(string sceneName);
        Task LoadSceneAsync(int sceneIndex);
        Task LoadSceneAsync(string sceneName);
    }
}