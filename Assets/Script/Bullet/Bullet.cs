using System.Collections;
using System.Collections.Generic;
using DG.DOTweenEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class Bullet : MonoBehaviour, IInitialisable, IProjectile
    {
        public PoolSystem Pool { get; set; }
        [SerializeField] float _speed = 100f;
        public void Initialize(Vector2 pos)
        {
            
        }

        public void Disable()
        {
            
        }

        public void Hit()
        {
            
        }
        
        public void Move()
        {
            
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
        
            
        }
    }
}
