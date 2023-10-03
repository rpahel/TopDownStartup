using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private Collider2D _entry;
        [SerializeField] private Collider2D[] _exits;

        [SerializeField] private PoolSystem _pool;
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
                _pool.Initialize(Vector2.zero);
                
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
