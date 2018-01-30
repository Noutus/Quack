using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(Rigidbody))]

public class WanderMovement : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private MoveBehaviour movement;

    private float wanderAngle;

    private void Awake()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
        this.movement = this.GetComponent<MoveBehaviour>();
    }

    void Update()
    {
        this.movement.Move(GetDirection());
    }

    public Vector3 GetDirection()
    {
        Vector3 circleCenter = Vector3.Normalize(this.rigidbody.velocity) * 10;
        Vector3 displacement = SetAngle(wanderAngle);

        wanderAngle += Random.Range(-0.33f, 0.33f);

        Vector3 wanderForce = Vector3.Normalize(circleCenter + displacement) * 100;

        return wanderForce * Time.deltaTime;
    }

    private Vector3 SetAngle(float n)
    {
        float l = 0.2f;
        float x = Mathf.Cos(n) * l;
        float z = Mathf.Sin(n) * l;

        return new Vector3(x, 0, z);
    }
}
