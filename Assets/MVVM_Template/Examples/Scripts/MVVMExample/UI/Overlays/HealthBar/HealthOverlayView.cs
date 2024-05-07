using DG.Tweening;
using MVVM.Core.Views;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVVMExample.UI.Overlays.HealthBar
{
    public class HealthOverlayView : BaseOverlayView<HealthOverlayViewModel>
    {
        [SerializeField] private Image _healthSlider;
        
        protected override void Bind()
        {
            _viewModel.healthModel.CurrentHealth
                .Subscribe(x => _healthSlider.DOFillAmount(x / _viewModel.healthModel.MaxHealth, 0.25f))
                .AddTo(_disposables);
        }

        protected override void Unbind()
        {
            
        }
    }
}