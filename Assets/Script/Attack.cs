using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public abstract class AttackClass : MonoBehaviour, IAttack, IDamager
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _coolDown;
        [SerializeField] private float _range;
        private Coroutine _attackCooldownCoroutine;
        private bool _canAttack;

        public int Damage => _damage;
        public float CoolDown => _coolDown;
        public float Range => _range;
        public bool CanAttack => _canAttack;

        private void Start()
        {
            _canAttack = true;
        }

        private void OnDisable()
        {
            if (_attackCooldownCoroutine != null)
            {
                StopCoroutine(_attackCooldownCoroutine);
                _attackCooldownCoroutine = null;
            }
        }

        public void StartAttackCooldown()
        {
            if (_attackCooldownCoroutine != null)
            {
                StopCoroutine(_attackCooldownCoroutine);
                _attackCooldownCoroutine = null;
            }

            _attackCooldownCoroutine = StartCoroutine(AttackCooldownCoroutine());
        }
        
        public virtual void Attack()
        {
            throw new System.NotImplementedException();
        }

        private IEnumerator AttackCooldownCoroutine()
        {
            yield return new WaitForSeconds(_coolDown);
            _canAttack = true;
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _range);
        }
    }
}
