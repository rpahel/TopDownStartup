using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PoolSystem : MonoBehaviour 
    {
        private Queue<IInitialisable> _objects =  new Queue<IInitialisable>();
        //private Queue<GameObject> _objects;
        //[SerializeField] private Spawner _spawner;
        [SerializeField] private Transform _playerTransform;
        
        [SerializeField] private GameObject _objectToInstantiate;
        [Min(0)]
        [SerializeField] private int _numberOfInstance;

        private IInitialisable _actualInitialisable;
        private void Start()
        {
            _objects = Spawn();

        }
        
        public Queue<IInitialisable> Spawn() 
        {
            if (_objectToInstantiate == null)
            {
                throw new ArgumentNullException(name + " Property \"GameObject to instantiate\" can't be null");
            }
                 
            Queue<IInitialisable> _objectQueue = new Queue<IInitialisable>();
            for (int i = 0; i < _numberOfInstance; i++)
            {
                _objectQueue.Enqueue(Instantiate(_objectToInstantiate, transform).GetComponent<IInitialisable>());
            }
            return _objectQueue;
        }
        
        public void Initialize(Vector2 pos)
        {
            _actualInitialisable = _objects.Dequeue();
            _actualInitialisable.Initialize(pos, _playerTransform);
        }
        
        public void ResetObject(IInitialisable initialisableObject)
        {
            _objects.Enqueue(initialisableObject);
            initialisableObject.Disable();
        }
    }
}
