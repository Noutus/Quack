using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnParent : MonoBehaviour {

    private Rigidbody parent;
    public Animator Animator { get; private set; }
    
    private void Awake()
    {
        this.Animator = this.GetComponent<Animator>();
    }

	private void Start ()
    {
        this.parent = this.transform.parent.GetComponent<Rigidbody>();
	}
	
	private void Update ()
    {
        if (this.parent.velocity.magnitude > 0)
            this.Animator.SetBool("Walking", true);
        else
            this.Animator.SetBool("Walking", false);
	}
}
