using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float TotalAliveTime = 1.0f;

    private float aliveTime;

    private void Awake()
    {
        this.aliveTime = 0.0f;
    }

    private void Update()
    {
        this.aliveTime += Time.deltaTime;
        if (this.aliveTime >= this.TotalAliveTime)
            GameObject.Destroy(this.gameObject);
    }
}
