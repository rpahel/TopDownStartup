using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KevinHealthProxy : MonoBehaviour, IKevinHealth
{
    [SerializeField, Required] KevinHealth _target;

    public void Damage(int amount) => _target.Damage(amount);
    public void Kill() => _target.Kill();
    public void Regen(int amount) => _target.Regen(amount);

}
