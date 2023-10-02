using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PoolSystem : MonoBehaviour
    {
        private Queue<object> _objects;
        [SerializeField] private Spawner _spawner;
        
        
        private void Start()
        {
            _objects = _spawner.Spawn<object>();
        }

        public void GetObject<T>()
        {
            
        }
        
        public void Initialize<T>(T item)
        {
            //appeller fonction des enemies pour les set up
            _objects.Dequeue();
            
        }
        
        public void Move<T>(T item, Vector3 pos)
        {
            
        }

        public void Reset<T>(T item)
        {
            
        }
    }
}
