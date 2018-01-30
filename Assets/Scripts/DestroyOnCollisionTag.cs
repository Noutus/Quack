using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionTag : MonoBehaviour
{
    public string Tag = "";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == this.Tag)
            GameObject.Destroy(this.gameObject);
    }
}
