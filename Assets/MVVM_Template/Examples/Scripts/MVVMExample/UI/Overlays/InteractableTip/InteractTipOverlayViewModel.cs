using MVVM.Core.ViewModels;
using MVVMExample.Infrastructure.AssetManagement;
using UnityEngine;

namespace MVVMExample.UI.Overlays.InteractableTip
{
    public class InteractTipOverlayViewModel : BaseOverlayViewModel
    {
        public override string AssetPath { get; protected set; } = AssetPaths.InteractTipOverlay;
        public Transform AnchorTransform { get; private set; }

        public InteractTipOverlayViewModel(Transform anchorTransform) : base(anchorTransform)
        {
            AnchorTransform = anchorTransform;
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}