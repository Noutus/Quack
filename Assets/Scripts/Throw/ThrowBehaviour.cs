using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBehaviour : MonoBehaviour
{
    public GameObject Projectile;

    private AnimateOnParent animator;

    private void Start()
    {
        this.animator = this.GetComponentInChildren<AnimateOnParent>();
    }

    private void Update()
    {
        if (Input.GetButtonUp(AxisNames.Throw))
        {
            this.animator.Animator.SetTrigger("Throw");

            var position = this.transform.position;
            var rotation = Quaternion.identity;
            var projectileObject = GameObject.Instantiate(Projectile, position, rotation);
            var projectileScript = projectileObject.GetComponent<ProjectileBehaviour>();
                projectileScript.Throw(MouseTracker.MousePosition);
        }
    }
}
