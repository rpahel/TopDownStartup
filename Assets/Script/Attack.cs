using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public abstract class AttackClass : MonoBehaviour, IAttack, IDamager
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _coolDown;
        private Coroutine _attackCooldownCoroutine;
        private bool _canAttack;

        public int GetDamage => _damage;
        public float CoolDown => _coolDown;
        public bool CanAttack => _canAttack;

        private void OnDisable()
        {
            if (_attackCooldownCoroutine != null)
            {
                StopCoroutine(_attackCooldownCoroutine);
                _attackCooldownCoroutine = null;
            }
        }

        private void OnEnable()
        {
            _canAttack = true;
        }

        public void StartAttackCooldown()
        {
            _canAttack = false;
            
            if (_attackCooldownCoroutine != null)
                return;
            
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
            _attackCooldownCoroutine = null;
        }
    }
}
