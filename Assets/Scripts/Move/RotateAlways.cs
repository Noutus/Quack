using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAlways : MonoBehaviour
{
    public bool AroundX = true;
    public bool AroundY = true;
    public bool AroundZ = true;

    public float RotationMinimum = 0.0f;
    public float RotationMaximum = 10.0f;

    private void Start()
    {
        this.Rotate(0.0f, 360.0f);
    }

    private void Update()
    {
        this.Rotate(this.RotationMinimum, this.RotationMaximum);
    }

    private void Rotate(float min, float max)
    {
        var xRotation = this.AroundX ? Random.Range(min, max) : 0.0f;
        var yRotation = this.AroundY ? Random.Range(min, max) : 0.0f;
        var zRotation = this.AroundZ ? Random.Range(min, max) : 0.0f;

        this.transform.Rotate(xRotation, yRotation, zRotation);
    }
}
