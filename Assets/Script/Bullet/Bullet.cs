using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour, IInitialisable, IProjectile
    {
        [SerializeField] float _speed = 50f;
        private Vector2 _direction;
        private GameObject _owner;
        private int _damageAmount;
        
        public PoolSystem Pool { get; set; }
        
        public void Initialize(Vector2 targetPos, Transform playerTransform)
        {
            transform.position = playerTransform.position;
            _direction = (targetPos - (Vector2)transform.position).normalized;
            _owner = playerTransform.gameObject;

            if (_owner.TryGetComponent(out IDamager damager))
                _damageAmount = damager.GetDamage;
            
            gameObject.SetActive(true);
        }

        private void Update()
        {
            transform.Translate(Time.deltaTime * _speed * _direction);
        }

        public void Disable()
        {
            transform.position = Vector3.zero;
            _direction = Vector2.zero;
            Pool.ResetObject(this);
            gameObject.SetActive(false);
        }

        public void Hit()
        {
            
        }
        
        public void Move()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                Disable();
            }
            else if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                if(_owner.layer == LayerMask.NameToLayer("Enemy"))
                    return;
                
                if(other.TryGetComponent(out Enemy enemy))
                    enemy.TakeDamage(_damageAmount);
                
                Disable();
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                if(_owner.layer == LayerMask.NameToLayer("Player"))
                    return;
                
                if (other.TryGetComponent(out Health health))
                    health.TakeDamage(_damageAmount);
                
                Disable();
            }
        }
    }
}
