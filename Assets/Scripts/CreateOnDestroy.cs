using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnDestroy : MonoBehaviour
{
    public GameObject Prefab;

    public Vector3 Offset;

    private void OnDestroy()
    {
        var position = this.transform.position + this.Offset;
        var rotation = Quaternion.identity;

        GameObject.Instantiate(Prefab, position, rotation);
    }
}
