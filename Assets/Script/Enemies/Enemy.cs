using System;
using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour, IDamageable, ICloneable, IAttack, IInitialisable
    {
        //== Fields ================================================
        [SerializeField] private EnemyDataSO _enemyData;
        
        private EnemyMovement _enemyMovement;
        private AttackClass _enemyAttack;
        
        //== Properties ============================================
        public int Health { get; private set; }
        public float Speed { get; private set; }
        public int Damage { get; private set; }
        public float FireRate { get; private set; }
        public AttackType AttackType { get; private set; }
        
        //== Events ================================================
        public event Action OnDie;
        
        //== Unity Methods =========================================
        private void Awake()
        {
            OnDie += PlayDeathAnimation;
            OnDie += PlayDeathSound;
        }

        private void OnDestroy()
        {
            OnDie -= PlayDeathAnimation;
            OnDie -= PlayDeathSound;
        }

        //== Interface Implementations =============================
        public object Clone()
        {
            Enemy clone = Instantiate(this);
            clone.Health = this.Health;
            clone.Speed = this.Speed;
            clone.Damage = this.Damage;
            clone.FireRate = this.FireRate;
            clone.AttackType = this.AttackType;
            clone._enemyData = this._enemyData;
            
            return clone;
        }

        public void Initialize()
        {
            if (!_enemyData)
                throw new NullReferenceException("Enemy " + name + " : _enemyData is null !");

            // On part du principe que si Health = 0,
            // l'ennemi a pas ete correctement initalise.
            // Car y'a pas de sens a faire spawn un mob a 0 pv.
            if (Health == 0) 
            {
                Health = _enemyData.GetHealth();
                Speed = _enemyData.GetSpeed();
                Damage = _enemyData.GetDamage();
                FireRate = _enemyData.GetFireRate();
                AttackType = _enemyData.GetAttackType();
            }

            // TODO : Heritage (EnemyAttackArcher, Warrior, etc) pareil pour movement.
            _enemyAttack = new EnemyAttack();
            _enemyMovement = new EnemyMovement();
        }

        // Todo : Appeler un methode de la class EnemyAttack
        public void Attack(){}

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
                Die();
        }
        
        //== Public Methods ========================================
        public string GetName()
        {
            if (!_enemyData)
                throw new NullReferenceException("Enemy " + name + " : _enemyData is null !");

            // Ptet une bonne idee ici de faire un stringbuilder avec les differents adjectifs de l'ennemi
            // Genre "Big Bad Scary Vicious Enemy Archer"
            
            return _enemyData.GetName();
        }
        
        //== Private Methods =======================================
        private void Die() => OnDie?.Invoke();
        private void PlayDeathAnimation(){}
        private void PlayDeathSound(){}
    }
}
