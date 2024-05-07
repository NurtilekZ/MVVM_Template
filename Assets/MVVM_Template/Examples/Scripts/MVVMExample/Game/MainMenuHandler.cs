using MVVMExample.Infrastructure.Bootstrap;
using MVVMExample.Infrastructure.Services.UI;
using MVVMExample.UI.Screens.MainMenu;
using UnityEngine;

namespace MVVMExample.Game
{
    public class MainMenuHandler : MonoBehaviour
    {
        private void Start()
        {
            ServiceLocator.GetService<IUIService>().Open(new MainMenuScreenViewModel());
        }
    }
}