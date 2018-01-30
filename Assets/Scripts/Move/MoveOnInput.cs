using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]

public class MoveOnInput : MonoBehaviour
{
    private MoveBehaviour moveBehaviour;

    private void Awake()
    {
        this.moveBehaviour = this.GetComponent<MoveBehaviour>();
    }

    private void Update()
    {
        var x = Input.GetAxis(AxisNames.Horizontal);
        var z = Input.GetAxis(AxisNames.Vertical);

        var direction = new Vector3(x, 0, z);

        this.moveBehaviour.Move(direction);
    }
}
