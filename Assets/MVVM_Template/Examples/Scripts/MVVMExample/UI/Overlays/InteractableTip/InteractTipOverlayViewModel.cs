using MVVM.Core.ViewModels;
using MVVMExample.Infrastructure.AssetManagement;
using UnityEngine;

namespace MVVMExample.UI.Overlays.InteractableTip
{
    public class InteractTipOverlayViewModel : BaseOverlayViewModel
    {
        public override string AssetPath { get; protected set; } = AssetPaths.InteractTipOverlay;

        public InteractTipOverlayViewModel(Transform anchorTransform) : base(anchorTransform)
        {
        }
    }
}