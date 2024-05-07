using MVVMExample.Game.DamageSystem;
using MVVMExample.Infrastructure.Bootstrap;
using MVVMExample.Infrastructure.Services.UI;
using MVVMExample.UI.Overlays.HealthBar;
using UnityEngine;

namespace MVVMExample.Game.Pawns
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _initialHealth;
        [SerializeField] private Transform _overlayAnchor;
        private PlayerHealthModel _healthModel;

        public PlayerHealthModel HealthModel => _healthModel;

        public void Awake()
        {
            _healthModel = new PlayerHealthModel(_initialHealth);
        }

        private async void Start()
        {
            var uiService = ServiceLocator.GetService<IUIService>();
            await uiService.Open(new HealthOverlayViewModel(_healthModel, _overlayAnchor));
        }

        public void TakeDamage(float damageValue, IDamageSender sender)
        {
            _healthModel.TakeDamage(damageValue, sender);
        }
    }
}