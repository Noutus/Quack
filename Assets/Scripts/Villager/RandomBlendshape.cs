using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]

public class RandomBlendshape : MonoBehaviour
{
    private SkinnedMeshRenderer blendshapes;

    public Material[] potentialMaterials;

    private void Start()
    {
        this.blendshapes = this.GetComponent<SkinnedMeshRenderer>();
        this.blendshapes.SetBlendShapeWeight(0, Random.Range(0, 100));
        this.blendshapes.SetBlendShapeWeight(1, Random.Range(0, 100));
        //this.blendshapes.SetBlendShapeWeight(2, Random.Range(0, 100));

        this.blendshapes.material = potentialMaterials[Random.Range(0, potentialMaterials.Length)];
    }
}
