using UnityEngine;

namespace Game
{
    public class EnemyMovement : MonoBehaviour
    {
        //== Fields ================================================
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private CircleCollider2D hitBox;
        
        //== Properties ============================================
        public Rigidbody2D Rb2D { private get; set; }
        public CircleCollider2D HitBox { private get; set; }
    }
}
