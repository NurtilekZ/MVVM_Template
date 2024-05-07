using MVVM.Core.ViewModels;
using MVVMExample.Game.DamageSystem;
using MVVMExample.Infrastructure.AssetManagement;

namespace MVVMExample.UI.Screens.GameHUD
{
    public class GameHUDViewModel : BaseViewModel
    {
        public override string AssetPath { get; protected set; } = AssetPaths.GameHUDScreen;

        public PlayerHealthModel PlayerHealthModel { get; }

        public GameHUDViewModel(PlayerHealthModel playerHealthModel)
        {
            PlayerHealthModel = playerHealthModel;
        }
    }
}