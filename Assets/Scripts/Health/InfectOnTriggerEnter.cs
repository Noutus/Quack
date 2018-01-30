using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class InfectOnTriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        InfectedBehaviour infection;
        if (infection = other.GetComponent<InfectedBehaviour>())
        {
            infection.Infect();
        }
    }
}
