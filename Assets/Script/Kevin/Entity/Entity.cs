using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Entity : MonoBehaviour
{
    [FormerlySerializedAs("_health")] [SerializeField, Required("nop")] KevinHealth kevinHealth;



}
