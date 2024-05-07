using MVVM.Core.ViewModels;
using MVVMExample.Infrastructure.AssetManagement;

namespace MVVMExample.UI.Screens.Loading
{
    public class LoadingScreenViewModel : BaseViewModel
    {
        public override bool IsInSceneCanvas { get; protected set; } = false;
        public override string AssetPath { get; protected set; } = AssetPaths.LoadingScreen;
        
        public LoadingScreenViewModel()
        {
        }
    }
}