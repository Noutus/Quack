using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    public GameObject attackPrefab;
    
    public void Attack()
    {
        var position = this.transform.position + this.transform.forward * 3;
        var rotation = Quaternion.identity;
        GameObject.Instantiate(attackPrefab, position, rotation, this.transform);
    }
}
