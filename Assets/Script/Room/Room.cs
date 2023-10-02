using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private Collider2D _entry;
        [SerializeField] private Collider2D _exit;

        [SerializeField] private PoolSystem _pool;
        [SerializeField] private int _numberOfArcher;
        [SerializeField] private int _numberOfWarriors;

        private float _numberOfEnemies;

        private void Start()
        {
            _numberOfEnemies = _numberOfArcher + _numberOfWarriors;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (CompareTag("Player"))
            {
                //Spawn des enemy
                _pool.Initialize(Vector2.zero);
                
                //Activate Exit Door
                _exit.gameObject.SetActive(true);
            }
        }

        private void EnemyDies()
        {
            //Check a la mort d'un enemi sur le _numberofEnemies == 0 et si oui Ouvrir la porte
        }
        
        
    }
}
