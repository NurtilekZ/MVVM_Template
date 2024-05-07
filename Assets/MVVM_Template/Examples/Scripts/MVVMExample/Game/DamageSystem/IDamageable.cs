namespace MVVMExample.Game.DamageSystem
{
    public interface IDamageable
    {
        void TakeDamage(float damageValue, IDamageSender sender);
    }
}