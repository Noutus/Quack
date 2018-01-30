using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public delegate void ProjectileEvent();
    public event ProjectileEvent OnGrounded;

    public float AirTime = 1.0f;
    public float Height = 5.0f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private float currentAirTime;

    private void Awake()
    {
        this.currentAirTime = 0.0f;
    }

    private void Update()
    {
        var previousAirTime = currentAirTime;
        this.currentAirTime += Time.deltaTime;
        if (this.currentAirTime >= this.AirTime && previousAirTime < this.AirTime)
            if (this.OnGrounded != null)
                this.OnGrounded();

        var lerpValue = Mathf.Clamp01(this.currentAirTime / this.AirTime);
        
        var y = this.Height * Mathf.Sin(lerpValue * Mathf.PI);
        var newPosition = Vector3.Lerp(this.startPosition, this.targetPosition, lerpValue);
            newPosition.y = y;    

        this.transform.position = newPosition;
    }

    public void Throw(Vector3 target)
    {
        this.startPosition = this.transform.position;
        this.targetPosition = target;
    }
}
