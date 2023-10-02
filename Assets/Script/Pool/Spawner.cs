using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace Game
{
    public class Spawner : MonoBehaviour
    {
        

        [SerializeField] private PoolSystem _poolSystem;


        private IEnumerator Start()
        {

            while (true)
            {
                //_poolSystem.();
                yield return new WaitForSeconds(1);
            }
        }
    }
}
