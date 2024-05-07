using MVVM.Core.ViewModels;
using MVVMExample.Game.DamageSystem;
using MVVMExample.Infrastructure.AssetManagement;
using UnityEngine;

namespace MVVMExample.UI.Overlays.HealthBar
{
    public class HealthOverlayViewModel : BaseOverlayViewModel
    {
        public override string AssetPath { get; protected set; } = AssetPaths.HealthOverlay;
        public readonly IHealthModel healthModel;

        public HealthOverlayViewModel(IHealthModel healthModel, Transform anchorTransform) : base(anchorTransform)
        {
            this.healthModel = healthModel;
        }
    }
}