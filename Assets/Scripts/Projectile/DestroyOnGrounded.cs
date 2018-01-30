using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileBehaviour))]

public class DestroyOnGrounded : MonoBehaviour
{
    private ProjectileBehaviour behaviour;

    private void Awake()
    {
        this.behaviour = this.GetComponent<ProjectileBehaviour>();
    }

    private void Start()
    {
        this.behaviour.OnGrounded += Grounded;
    }

    private void OnDestroy()
    {
        this.behaviour.OnGrounded -= Grounded;
    }

    private void Grounded()
    {
        GameObject.Destroy(this.gameObject);
    }
}
