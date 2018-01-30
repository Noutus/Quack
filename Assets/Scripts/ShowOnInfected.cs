using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InfectedBehaviour))]

public class ShowOnInfected : MonoBehaviour
{
    public GameObject Prefab;

    private InfectedBehaviour infection;
    private GameObject infectionParticles;

    private void Awake()
    {
        this.infection = this.GetComponent<InfectedBehaviour>();
    }

    private void Start()
    {
        this.infection.OnInfectionStart += InfectionStart;
        this.infection.OnInfectionEnd += InfectionEnd;
    }

    private void OnDestroy()
    {
        if (this.infectionParticles != null)
            GameObject.Destroy(this.infectionParticles);

        this.infection.OnInfectionStart -= InfectionStart;
        this.infection.OnInfectionEnd -= InfectionEnd;
    }

    private void InfectionEnd()
    {
        GameObject.Destroy(this.infectionParticles);
    }

    private void InfectionStart()
    {
        this.infectionParticles = GameObject.Instantiate(Prefab, this.transform);
        this.infectionParticles.transform.Translate(Vector3.forward * 1.0f);
    }
}
