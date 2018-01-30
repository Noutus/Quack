using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InfectedBehaviour))]

public class InfectionIncubation : MonoBehaviour
{
    public float incubationTime = 10.0f;

    private InfectedBehaviour infection;

    private void Awake()
    {
        this.infection = this.GetComponent<InfectedBehaviour>();
    }

    private void Update()
    {
        if (this.infection.Infected)
            this.infection.AdjustLevels(Time.deltaTime / this.incubationTime);
    }
}
