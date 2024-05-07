using UniRx;

namespace MVVMExample.Game.DamageSystem
{
    public interface IHealthModel : IDamageable
    {
        IReadOnlyReactiveProperty<float> CurrentHealth { get; }
        float MaxHealth { get; }
    }
}