using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTowardsTarget : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private Transform target;

    public GameObject Projectile;

    private MoveBehaviour movement;

    Coroutine coroutine;
    private bool coroutinerunning = false;

    private void Start()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
        this.movement = this.GetComponent<MoveBehaviour>();
    }

    public void Setup(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (Vector3.Distance(this.target.position, this.transform.position) > 1)
        {
            if (this.target != null)
            {
                var targetVector = this.target.position - this.transform.position;
                this.movement.Move(targetVector.normalized);
            }
        }

        else
        {
            this.movement.Move(Vector3.zero);

            if (!this.coroutinerunning)
            {
                this.StartCoroutine(ThrowFlask());
            }
        }
    }

    private IEnumerator ThrowFlask()
    {
        this.coroutinerunning = true;

        yield return new WaitForSeconds(4);

        var position = this.transform.position;
        var rotation = Quaternion.identity;
        var projectileObject = GameObject.Instantiate(Projectile, position, rotation);
        var projectileScript = projectileObject.GetComponent<ProjectileBehaviour>();

        var angle = UnityEngine.Random.Range(0, 360);
        var target = this.transform.position + 10 * new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));

        projectileScript.Throw(target);

        this.coroutinerunning = false;
    }
}
