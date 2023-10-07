using UnityEngine;

namespace Game
{
    public class EnemyAI : MonoBehaviour
    {
        //== Fields ================================================
        [SerializeField] private Enemy _enemy;
        [SerializeField] private float _detectionRadius;
        [SerializeField] private float _nearPlayerRadius;
        
        //== Properties ============================================
        public Transform PlayerTransform { get; set; }
        public Enemy Enemy { protected get { return _enemy; } set { _enemy = value; } }
        protected float DetectionRadius => _detectionRadius;
        protected float NearPlayerRadius => _nearPlayerRadius;
        protected Vector2 EnemyToPlayer { get; private set; }
        
        //== Protected Methods =======================================
        protected bool IsPlayerInRange(float range)
        {
            if (!PlayerTransform)
                return false;
            
            EnemyToPlayer = PlayerTransform.position - transform.position;
            return EnemyToPlayer.sqrMagnitude < (range * range);
        }
        
        //== Editor Methods ========================================
        private void OnDrawGizmosSelected()
        {
            Vector2 selfPos = transform.position;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(selfPos, _nearPlayerRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(selfPos, _detectionRadius);
        }
    }
}
