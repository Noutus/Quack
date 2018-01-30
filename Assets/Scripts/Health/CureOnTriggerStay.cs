using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureOnTriggerStay : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        InfectedBehaviour infection;
        if (infection = other.GetComponent<InfectedBehaviour>())
        {
            infection.Disinfect();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        InfectedBehaviour infection;
        if (infection = other.GetComponent<InfectedBehaviour>())
        {
            infection.AdjustLevels(-Time.deltaTime);
        }
    }
}
