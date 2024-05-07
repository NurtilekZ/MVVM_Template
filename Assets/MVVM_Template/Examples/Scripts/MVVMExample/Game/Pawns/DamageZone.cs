using System.Collections;
using MVVMExample.Game.DamageSystem;
using UnityEngine;

namespace MVVMExample.Game.Pawns
{
    public class DamageZone : BaseDamageSender
    {
        [SerializeField] private float _damageValue = 5f;
        [SerializeField] private float _damageInterval = 1f;
        
        private IEnumerator _dealDamageCoroutine;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<IDamageable>(out var damageable))
            {
                _dealDamageCoroutine = DealDamage(damageable);
                StartCoroutine(_dealDamageCoroutine);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.root.TryGetComponent<IDamageable>(out _))
            {
                StopCoroutine(_dealDamageCoroutine);
                _dealDamageCoroutine = null;
            }
        }

        private IEnumerator DealDamage(IDamageable damageable)
        {
            while (true)
            {
                if (!enabled) yield return new WaitUntil(() => enabled);
                Attack(damageable);
                yield return new WaitForSeconds(_damageInterval);
            }
        }

        protected override void Attack(IDamageable damageable)
        {
            damageable.TakeDamage(_damageValue, this);
        }
    }
}