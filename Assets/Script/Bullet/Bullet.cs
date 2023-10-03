using System;
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
        [SerializeField] float _speed = 50f;
        private Vector2 direction;
        public void Initialize(Vector2 pos, Transform playerTransform)
        {
            Debug.Log(playerTransform);
            transform.position = playerTransform.position;
            direction = (pos - (Vector2)transform.position).normalized;
            gameObject.SetActive(true);
        }

        private void Update()
        {
            transform.Translate(direction*Time.deltaTime*_speed);
        }

        public void Disable()
        {
            transform.position = Vector3.zero;
            direction = Vector2.zero;
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
        }
    }
}
