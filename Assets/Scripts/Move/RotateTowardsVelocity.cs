using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class RotateTowardsVelocity : MonoBehaviour
{
    private new Rigidbody rigidbody;

    private void Awake()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (this.rigidbody.velocity.magnitude > 0)
            this.transform.rotation = Quaternion.LookRotation(this.rigidbody.velocity);
    }
}
