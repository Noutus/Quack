using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBehaviour))]

public class DieOnHealth0 : MonoBehaviour
{
    private HealthBehaviour health;
    
    private void Awake()
    {
        this.health = this.GetComponent<HealthBehaviour>();
    }

    private void Start()
    {
        this.health.OnHealth += HealthChanged;
    }

    private void HealthChanged(uint current)
    {
        if (current == 0)
            Debug.Log("You have died...");
    }

    private void OnDestroy()
    {
        this.health.OnHealth -= HealthChanged;
    }
}
