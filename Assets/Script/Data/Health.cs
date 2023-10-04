using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using Game;
using System.Security.Cryptography;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private Alterable<int> _maxHealth;

    public int CurrentHealth { get; private set; }

    public bool IsDead => CurrentHealth > 0;
    public Alterable<int> MaxHealth { get => _maxHealth ??= new Alterable<int>(CurrentHealth); }

    public event Action<int> OnDamage;
    public event Action<int> OnRegen;
    public event Action OnDie;

    public void TakeDamage(int amount)
    {
        Assert.IsTrue(amount >= 0);
        if (IsDead) return;

        Debug.Log(name + " Damage received : " + amount);

        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        OnDamage?.Invoke(amount);
    }
    public void Regen(int amount)
    {
        Assert.IsTrue(amount >= 0);
        if (IsDead) return;
        InternalRegen(amount);
    }
    public void Die()
    {
        if (IsDead) return;
        InternalDie();
    }

    public void Revive(int amount)
    {
        Assert.IsTrue(amount >= 0);
        if (!IsDead) return;
        InternalRegen(amount);
    }

    void InternalRegen(int amount)
    {
        Assert.IsTrue(amount >= 0);

        var old = CurrentHealth;
        CurrentHealth = Mathf.Min(_maxHealth.CalculateValue(), CurrentHealth + amount);
        OnRegen?.Invoke(CurrentHealth-old);
    }
    void InternalDie()
    {
        if (!IsDead) return;
        OnDie?.Invoke();
    }
}
