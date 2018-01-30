using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class DamageOnTriggerEnter : MonoBehaviour
{
    public uint Amount = 1;

    private void OnTriggerEnter(Collider other)
    {
        HealthBehaviour health;
        if (health = other.GetComponent<HealthBehaviour>())
            health.Damage(this.Amount);
    }
}
