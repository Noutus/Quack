using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHealthOnInput : MonoBehaviour
{
    private HealthBehaviour health;

    private void Awake()
    {
        this.health = this.GetComponent<HealthBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            this.health.Damage(1);
    }
}
