using System;
using MVVMExample.Infrastructure.Services.UI;

namespace MVVM.Core.Interfaces
{
    public interface IViewModel : IDisposable
    {
        bool IsInSceneCanvas { get; }
        string AssetPath { get; }
        IUIService _uiService { get; }
    }
}