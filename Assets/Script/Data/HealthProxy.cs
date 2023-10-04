using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class HealthProxy : MonoBehaviour, IHealth
{
    [SerializeField, Required] Health _target;

    public void TakeDamage(int amount) => _target.TakeDamage(amount);
    public void Die() => _target.Die();
    public void Regen(int amount) => _target.Regen(amount);

}
