using UnityEngine;

namespace Game
{
    public class EnemyAI : MonoBehaviour
    {
        //== Fields ================================================
        [SerializeField] private Enemy enemy;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float detectionRadius;
        [SerializeField] private float nearPlayerRadius;
        
        //== Properties ============================================
        public Transform PlayerTransform { protected get; set; }
        public Enemy Enemy { protected get { return enemy; } set { enemy = value; } }
        protected float DetectionRadius => detectionRadius;
        protected float NearPlayerRadius => nearPlayerRadius;
        protected Vector2 EnemyToPlayer { get; private set; }
        
        //== Protected Methods =======================================
        protected bool IsPlayerInRange(float range)
        {
            if (!playerTransform)
                return false;
            
            EnemyToPlayer = playerTransform.position - transform.position;
            return EnemyToPlayer.sqrMagnitude < (range * range);
        }
        
        //== Editor Methods ========================================
        private void OnDrawGizmosSelected()
        {
            Vector2 selfPos = transform.position;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(selfPos, nearPlayerRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(selfPos, detectionRadius);
        }
    }
}
