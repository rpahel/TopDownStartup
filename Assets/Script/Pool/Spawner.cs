using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace Game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToInstantiate;
        [Min(0)]
        [SerializeField] private int _numberOfInstance;
        
        
        public Queue<T>Spawn<T>()
        {
            if (_objectToInstantiate == null)
            {
                throw new ArgumentNullException(name + " Property \"GameObject to instantiate\" can't be null");
            }
                 
            Queue<T> _objectQueue = new Queue<T>();
            for (int i = 0; i < _numberOfInstance; i++)
            {
                _objectQueue.Enqueue(Instantiate(_objectToInstantiate, transform).GetComponent<T>());
            }
            return _objectQueue;
        }
        
        
        
    }
}
