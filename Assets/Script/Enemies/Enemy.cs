using System;
using UnityEngine;
using System.Linq;

namespace Game
{
    public class Enemy : MonoBehaviour, IHealth, ICloneable, IInitialisable
    {
        //== Fields ================================================
        [SerializeField] private EnemyDataSO _enemyData;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private AttackClass _enemyAttack;
        [SerializeField] private EnemyAI _enemyAI;
        
        //== Properties ============================================
        public int Health { get; private set; }
        public float Speed { get; private set; }
        public int Damage { get; private set; }
        public float FireRate { get; private set; }
        public AttackType AttackType { get; private set; }
        public EnemyMovement GetMovement => _enemyMovement;
        public EnemyAI GetBrain => _enemyAI;
        public AttackClass GetAttack => _enemyAttack;
        
        //== Events ================================================
        public event Action OnDie;
        
        //== Unity Methods =========================================
        private void Awake()
        {
            OnDie += PlayDeathAnimation;
            OnDie += PlayDeathSound;
            OnDie += DisableSelf;
        }

        private void Start()
        {
            if(_enemyAttack as EnemyAttack)
                (_enemyAttack as EnemyAttack).Enemy = this;
        }

        private void OnDestroy()
        {
            OnDie = null;
        }

        private void OnDisable()
        {
            if (!_enemyData)
                throw new NullReferenceException("Enemy " + name + " : _enemyData is null !");

            Health = _enemyData.GetHealth();
            Speed = _enemyData.GetSpeed();
            Damage = _enemyData.GetDamage();
            FireRate = _enemyData.GetFireRate();
            AttackType = _enemyData.GetAttackType();
            
            VFXManager.Instance.DeathVFX(transform);

            Pool.ResetObject(this);
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

        public PoolSystem Pool { get; set; }
        public Room Room { get; set; }

        public void Initialize(Vector2 spawnPos, Transform playerTransform = null)
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
            
            transform.position = spawnPos;
            _enemyAI.PlayerTransform = playerTransform;
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
        
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
                Die();
        }

        public void Regen(int amount)
        {
            Health = Mathf.Clamp(Health + amount, Health, _enemyData.GetHealth());
        }

        public void Die() => OnDie?.Invoke();

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
        private void PlayDeathAnimation()
        {
            Debug.Log(name + " : *Dies*");
        }

        private void PlayDeathSound()
        {
            Debug.Log(name + " : Eurgh !");
        }

        private void DisableSelf()
        {
            Room.EnemyDies();
            
            gameObject.SetActive(false);
        }
    }
}
