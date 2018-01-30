using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedBehaviour : MonoBehaviour
{
    public delegate void InfectionEvent();
    public event InfectionEvent OnInfectionStart;
    public event InfectionEvent OnInfectionEnd;

    private float previousInfectionLevel;
    private float infectionLevel;

    public bool Infected { get; private set; }

    private void Awake()
    {
        this.Infected = false;
        this.infectionLevel = 0.0f;
        this.previousInfectionLevel = 0.0f;
    }

    public void Infect()
    {
        this.Infected = true;
    }

    public void Disinfect()
    {
        this.Infected = false;
    }

    public void AdjustLevels(float adjustment)
    {
        this.infectionLevel = Mathf.Clamp01(this.infectionLevel + adjustment);
        
        if (this.previousInfectionLevel == 0 && this.infectionLevel > 0 && this.OnInfectionStart != null)
            this.OnInfectionStart();

        if (this.previousInfectionLevel > 0 && this.infectionLevel == 0 && this.OnInfectionEnd != null)
            this.OnInfectionEnd();

        this.previousInfectionLevel = this.infectionLevel;
    }
}
