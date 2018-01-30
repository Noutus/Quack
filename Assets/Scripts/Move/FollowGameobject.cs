using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameobject : MonoBehaviour
{
    public GameObject Target;

    private Vector3 relativePosition;

    private void Start()
    {
        this.relativePosition = this.transform.position - this.Target.transform.position;
    }

    private void Update()
    {
        this.transform.position = this.Target.transform.position + this.relativePosition;
    }
}
