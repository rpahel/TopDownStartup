using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour, IHealth, ICloneable, IAttack, IInitialisable
    {
        //== Fields ================================================
        [SerializeField] private EnemyDataSO _enemyData;
        
        //== Properties ============================================
        public int Health { get; set; }
        public float Speed { get; set; }
        public float FireRate { get; set; }

        //== Constructors ==========================================
        public Enemy()
        {
            OnDie += PlayDeathAnimation;
            OnDie += PlayDeathSound;
        }
        
        //== Events ================================================
        public event Action OnDie;
        
        //== Interface Implementations =============================
        public object Clone()
        {
            Enemy clone = Instantiate(this);
            clone.Health = this.Health;
            clone.Speed = this.Health;
            clone.FireRate = this.FireRate;
            clone._enemyData = this._enemyData;
            
            return clone;
        }

        public void Initialize()
        {
            if (_enemyData == null)
                return;
            
            // Creer des components et les peupler
            // Genre creer un SpriteRenderer et y mettre le sprite indiqué dans le SO
        }

        public virtual void Attack(){}

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
                Die();
        }

        public void Die()
        {
            OnDie?.Invoke();
        }
        
        //== Private Methods =======================================
        private void PlayDeathAnimation(){}
        private void PlayDeathSound(){}
    }
}
