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
            
            pool.Initialize(p);
            
        }
    }
}
