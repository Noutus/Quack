using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsParentVelocity : MonoBehaviour
{
    private Rigidbody parent;

	void Start ()
    {
		this.parent = this.transform.parent.GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        if (this.parent.velocity.magnitude > 0)
            this.transform.rotation = Quaternion.LookRotation(-this.parent.velocity);
        else
        {
            this.transform.LookAt(MouseTracker.MousePosition);
            this.transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + 180, 0));
        }
    }
}
