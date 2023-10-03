using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

namespace Game
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] InputActionReference _mousePosition;
        [SerializeField] Camera _referenceCamera;
        [SerializeField] private PoolSystem pool;

        public void Shoot()
        {
            var p = _referenceCamera.ScreenToWorldPoint(_mousePosition.action.ReadValue<Vector2>());
            
            //faire le calcul pour chopper la direction (normaliser) vers la souris pour donner ca comme vector acceleration a la bullet
            pool.Initialize(Vector2.zero);
            
        }
    }
}
