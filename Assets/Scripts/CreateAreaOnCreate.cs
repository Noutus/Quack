using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAreaOnCreate : MonoBehaviour
{
    public GameObject AreaPrefab;

    public int Difficulty = 5;

    private void Start()
    {
        this.SpawnForward(0, 1, 1);
        this.SpawnForward(0, 1, -1);
        this.SpawnRight2(1, 0, 1);
        this.SpawnRight2(1, 0, -1);
    }

    private int SpawnForward(int xDepth, int zDepth, int mult)
    {
        int forward = 0;
        int right = 0;

        this.SpawnArea(xDepth * mult, zDepth * mult);

        if (Random.Range(0.0f, (float)this.Difficulty) > zDepth)
        {
            forward = this.SpawnForward(xDepth, zDepth + 1, mult);
            right = this.SpawnRight(xDepth + 1, zDepth, mult);
        }

        return 1 + forward + right;
    }

    private int SpawnRight(int xDepth, int zDepth, int mult)
    {
        int right = 0;

        this.SpawnArea(xDepth * mult, zDepth * mult);

        if (Random.Range(0.0f, (float)this.Difficulty) > xDepth)
        {
            right = this.SpawnRight(xDepth + 1, zDepth, mult);
        }

        return 1 + right;
    }
    
    private int SpawnRight2(int xDepth, int zDepth, int mult)
    {
        int forward = 0;
        int right = 0;

        this.SpawnArea(xDepth * mult, zDepth * mult);

        if (Random.Range(0.0f, (float)this.Difficulty) > xDepth)
        {
            forward = this.SpawnRight2(xDepth + 1, zDepth, mult);
            right = this.SpawnBack(xDepth, zDepth + 1, mult);
        }

        return 1 + forward + right;
    }

    private int SpawnBack(int xDepth, int zDepth, int mult)
    {
        int right = 0;

        this.SpawnArea(xDepth * mult, -zDepth * mult);

        if (Random.Range(0.0f, (float)this.Difficulty) > zDepth)
        {
            right = this.SpawnBack(xDepth, zDepth + 1, mult);
        }

        return 1 + right;
    }

    private void SpawnArea(int x, int z)
    {
        var position = new Vector3(25 * x, 0, 25 * z);
        var rotation = Quaternion.identity;

        GameObject.Instantiate(this.AreaPrefab, position, rotation);
    }
}
