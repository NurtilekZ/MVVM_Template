using UnityEngine;

namespace MVVMExample.Game.DamageSystem
{
    public abstract class BaseDamageSender : MonoBehaviour, IDamageSender
    {
        protected abstract void Attack(IDamageable damageable);
    }
}