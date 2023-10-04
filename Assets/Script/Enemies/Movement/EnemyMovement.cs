using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class EnemyMovement : MonoBehaviour
    {
        //== Fields ================================================
        [SerializeField] private Rigidbody2D _rb2D;
        [Space(10)]
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;
        
        //== Public Methods ========================================
        public void ContinuousMove(Vector2 direction)
        {
            if (direction.sqrMagnitude < 1f)
                return;
            
            if(_rb2D.velocity.sqrMagnitude < _maxSpeed * _maxSpeed)
                _rb2D.AddForce(direction * _acceleration);
        }
    }
}
