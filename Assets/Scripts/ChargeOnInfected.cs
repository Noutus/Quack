using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeOnInfected : MonoBehaviour
{
    private MoveBehaviour movement;
    private WanderMovement wander;
    private InfectedBehaviour infection;

    private Transform target;

    private bool charging = false;

    private void Awake()
    {
        this.movement = this.GetComponent<MoveBehaviour>();
        this.wander = this.GetComponent<WanderMovement>();
        this.infection = this.GetComponent<InfectedBehaviour>();
    }

    private void Start()
    {
        this.target = GameObject.Find("Plague Doctor").transform;
    }

    private void Update()
    {
        if (infection.Infected)
        { 
            if (this.charging)
            {
                var targetVector = this.target.transform.position - this.transform.position;
                this.movement.Move(targetVector.normalized * movement.Speed);
            }

            else
            {
                if (Random.Range(0, 10000) > 9990)
                    StartCoroutine(Charge());
            }
        }
    }
    
    private IEnumerator Charge()
    {
        this.charging = true;
        this.wander.enabled = false;

        yield return new WaitForSeconds(5);

        this.wander.enabled = true;
        this.charging = false;
    }
}
