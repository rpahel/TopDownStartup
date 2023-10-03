using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Game
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private Collider2D _entry;
        [SerializeField] private Collider2D[] _exits;

        [SerializeField] private Transform[] _spawns;

        [SerializeField] private PoolSystem _archerPool;
        [SerializeField] private PoolSystem _warriorPool;
        [SerializeField] private int _numberOfArcher;
        [SerializeField] private int _numberOfWarriors;

        private float _numberOfEnemies;

        private void Start()
        {
            _numberOfEnemies = _numberOfArcher + _numberOfWarriors;
            foreach (var EXIT in _exits)
            {
                EXIT.gameObject.SetActive(false);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                //Spawn des enemy
                if (_spawns.Length == 0)
                {
                    throw new ArgumentNullException(name + " The number of Spawns point is 0 ");
                }
                for (int i = 0; i < _numberOfArcher; i++)
                {
                    _archerPool.Initialize(_spawns[UnityEngine.Random.Range(0, _spawns.Length)].position);
                }
                
                for (int i = 0; i < _numberOfWarriors; i++)
                {
                    _archerPool.Initialize(_spawns[UnityEngine.Random.Range(0, _spawns.Length)].position);
                }
                
                
                //Activate Exit Door
                foreach (var EXIT in _exits)
                {
                    EXIT.gameObject.SetActive(true);
                }
            }
        }

        private void EnemyDies()
        {
            //Check a la mort d'un enemi sur le _numberofEnemies == 0 et si oui Ouvrir la porte
        }
        
        
    }
}
