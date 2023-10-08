using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

namespace Game
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private Collider2D[] _exits;
        
        [SerializeField] private Transform[] _spawns;

        [SerializeField] private PoolSystem _archerPool;
        [SerializeField] private PoolSystem _warriorPool;
        [SerializeField] private int _numberOfArcher;
        [SerializeField] private int _numberOfWarriors;

        private List<Enemy> _enemies = new List<Enemy>();

        [SerializeField] private UnityEvent OnStartRoom;
        [SerializeField] private UnityEvent OnClearRoom;

        private bool isClear;
        private bool isEntered;

        private float _numberOfEnemies;

        private void Start()
        {
            _numberOfEnemies = _numberOfArcher + _numberOfWarriors;
            isClear = false;
            isEntered = false;
            foreach (var EXIT in _exits)
            {
                EXIT.gameObject.SetActive(false);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player") && isClear == false && isEntered == false)
            {
                isEntered = true;
                //Spawn des enemy
                if (_spawns.Length == 0)
                {
                    throw new ArgumentNullException(name + " The number of Spawns point is 0 ");
                }
                
                //Event VFX / Audio
                OnStartRoom.Invoke();
                
                for (int i = 0; i < _numberOfArcher; i++)
                {
                    Enemy newArcher = (Enemy)_archerPool.Initialize(_spawns[UnityEngine.Random.Range(0, _spawns.Length)].position);
                    _enemies.Add(newArcher);
                    newArcher.OnDie += EnemyDies;
                    newArcher.Room = this;
                }
                
                for (int i = 0; i < _numberOfWarriors; i++)
                {
                    Enemy newWarrior = (Enemy)_warriorPool.Initialize(_spawns[UnityEngine.Random.Range(0, _spawns.Length)].position);
                    _enemies.Add(newWarrior);
                    newWarrior.OnDie += EnemyDies;
                    newWarrior.Room = this;
                }

                
                //Activate Exit Door
                foreach (var EXIT in _exits)
                {
                    EXIT.gameObject.SetActive(true);
                }
            }
        }

        private void RoomCleared()
        {
            //Event VFX / Audio
            OnClearRoom.Invoke();
            foreach (var EXIT in _exits)
            {
                isClear = false;
                EXIT.gameObject.SetActive(false);
            }
        }

        public void EnemyDies()
        {
            //Debug.Log(_numberOfEnemies);
            if (_numberOfEnemies > 0)
            {
                _numberOfEnemies--;
            }
            
            if (_numberOfEnemies == 0)
            {
                RoomCleared();
            }
        }
        
        
    }
}
