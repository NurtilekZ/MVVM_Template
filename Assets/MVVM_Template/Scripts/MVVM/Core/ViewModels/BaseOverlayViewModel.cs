using MVVM.Core.Interfaces;
using UnityEngine;

namespace MVVM.Core.ViewModels
{
    public abstract class BaseOverlayViewModel : BaseViewModel, IOverlayViewModel
    {
        public Transform AnchorTransform { get; }

        protected BaseOverlayViewModel(Transform anchorTransform) 
        {
            AnchorTransform = anchorTransform;
        }
    }
}