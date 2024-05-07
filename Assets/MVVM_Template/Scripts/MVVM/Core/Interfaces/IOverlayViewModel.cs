using UnityEngine;

namespace MVVM.Core.Interfaces
{
    public interface IOverlayViewModel : IViewModel
    {
        Transform AnchorTransform { get; }
    }
}