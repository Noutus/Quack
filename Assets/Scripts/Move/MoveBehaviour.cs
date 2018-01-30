using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MoveBehaviour : MonoBehaviour
{
    public float Speed = 1.0f;
    
    private new Rigidbody rigidbody;
    
    private void Awake()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
    }
    
    public void Move(Vector3 direction)
    {
        this.rigidbody.velocity = this.Speed * direction;
    }
}
