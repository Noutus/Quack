using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    public delegate void HealthEvent(uint current);
    public event HealthEvent OnHealth;

    public uint MaxHealth = 1;

    private uint health;

    private void Awake()
    {
        this.health = this.MaxHealth;
    }

    public void Damage(uint damage)
    {
        this.health -= damage;
        if (OnHealth != null)
            OnHealth(this.health);
    }
}
