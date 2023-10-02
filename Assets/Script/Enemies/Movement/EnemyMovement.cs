using UnityEngine;

namespace Game
{
    public class EnemyMovement : MonoBehaviour
    {
        //== Fields ================================================
        [SerializeField] private Enemy enemy;
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private CircleCollider2D hitBox;
        [Space(10)]
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;
        
        //== Public Methods ========================================
        public void ContinuousMove(Vector2 direction)
        {
            if(rb2D.velocity.sqrMagnitude < maxSpeed * maxSpeed)
                rb2D.AddForce(direction * acceleration);
        }
    }
}
