using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class DamageGetter : MonoBehaviour
    {
        [SerializeField] private IDamager _damagingScript;
    }
}
