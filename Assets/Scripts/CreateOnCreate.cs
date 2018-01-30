using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnCreate : MonoBehaviour
{
    public GameObject[] prefabs;

    private void Start()
    {
        var position = this.transform.position;

        GameObject.Instantiate(prefabs[Random.Range(0, prefabs.Length)], position, Quaternion.identity);
        GameObject.Instantiate(prefabs[Random.Range(0, prefabs.Length)], position, Quaternion.identity);

        GameObject.Destroy(this.gameObject);
    }
}
