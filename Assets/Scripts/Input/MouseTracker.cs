using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    public static Vector3 MousePosition;

    private Plane zeroPlane = new Plane(Vector3.up, Vector3.zero);

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var rayDistance = 0.0f;
        if (zeroPlane.Raycast(ray, out rayDistance))
            MousePosition = ray.GetPoint(rayDistance);
    }
}
