using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseOnHealth0 : MonoBehaviour
{
    public GameObject InsectPrefab;
    public GameObject QuackPrefab;

    private HealthBehaviour health;

    private void Awake()
    {
        this.health = this.GetComponent<HealthBehaviour>();
    }

    private void Start()
    {
        this.health.OnHealth += HealthChanged;
    }

    private void HealthChanged(uint current)
    {
        if (current == 0)
            Die();
    }

    private void OnDestroy()
    {
        this.health.OnHealth -= HealthChanged;
    }

    private void Die()
    {
        GameObject.Destroy(this.GetComponent<WanderMovement>());
        GameObject.Destroy(this.GetComponent<MoveBehaviour>());
        GameObject.Destroy(this.GetComponent<HealthBehaviour>());
        GameObject.Destroy(this.GetComponent<ShowOnInfected>());
        GameObject.Destroy(this.GetComponent<InfectionIncubation>());
        GameObject.Destroy(this.GetComponent<InfectedBehaviour>());
        GameObject.Destroy(this.GetComponent<RotateTowardsVelocity>());
        GameObject.Destroy(this.GetComponent<Rigidbody>());
        GameObject.Destroy(this.GetComponentInChildren<Animator>());

        this.StartCoroutine(FallOver());
    }

    private IEnumerator FallOver()
    {
        while (this.transform.rotation.eulerAngles.x < 90)
        {
            this.transform.Rotate(4.5f, 0, 0);
            yield return null;
        }
        
        GameObject.Instantiate(this.InsectPrefab, this.transform);

        var farAway = new Vector3(this.transform.position.x + 40, 0, 0);
        var quack = GameObject.Instantiate(this.QuackPrefab, farAway, Quaternion.identity);
            quack.GetComponent<WalkTowardsTarget>().Setup(this.transform);
    }
}
