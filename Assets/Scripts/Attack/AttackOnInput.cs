using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackBehaviour))]

public class AttackOnInput : MonoBehaviour
{
    private AttackBehaviour attack;
    private AnimateOnParent animator;

    private void Awake()
    {
        this.attack = this.GetComponent<AttackBehaviour>();
    }

    private void Start()
    {
        this.animator = this.GetComponentInChildren<AnimateOnParent>();
    }

    private void Update()
    {
        if (Input.GetButtonUp(AxisNames.Attack))
        {
            this.attack.Attack();
            this.animator.Animator.SetTrigger("Hit");
        }
    }
}
