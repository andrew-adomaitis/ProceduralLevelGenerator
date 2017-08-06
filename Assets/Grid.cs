using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshRenderer), typeof(MeshFilter))]
public class Grid : MonoBehaviour
{
    public int xSize, ySize;
    public float waitLength = 0.05f;

    Vector3[] vertices;

    void Awake()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(waitLength);
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];

        for(int i = 0, y = 0; y <= ySize; y++)
        {
            for(int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
                yield return wait;
            }
        }
    }

    void OnDrawGizmos()
    {
        if(vertices == null)
        {
            return;
        }

        Gizmos.color = Color.black;
        for(int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
