using UniRx;

namespace MVVMExample.Game.DamageSystem
{
    public class PlayerHealthModel : IHealthModel
    {
        private readonly ReactiveProperty<float> _currentHealth;

        public IReadOnlyReactiveProperty<float> CurrentHealth => _currentHealth;

        public float MaxHealth { get; }
        
        public PlayerHealthModel(float currentHealth, float maxHealth = 0)
        {
            _currentHealth = new ReactiveProperty<float>(currentHealth);
            MaxHealth = maxHealth > 0 ? maxHealth : currentHealth;
        }


        public void TakeDamage(float damageValue, IDamageSender sender)
        {
            if (damageValue < 0)
            {
                damageValue = -damageValue;
                if (_currentHealth.Value == MaxHealth) return;
            
                if (_currentHealth.Value + damageValue < MaxHealth)
                    _currentHealth.Value += damageValue;
                else
                    _currentHealth.Value = MaxHealth;
                
                return;
            }
            if (_currentHealth.Value == 0) return;
            
            if (_currentHealth.Value - damageValue > 0)
                _currentHealth.Value -= damageValue;
            else
                _currentHealth.Value = 0;
        }
    }
}