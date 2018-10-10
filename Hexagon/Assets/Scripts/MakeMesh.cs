using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMesh : MonoBehaviour
{
    private float sideLength = 1.0f;
    
    private Mesh mesh;

    public Mesh GenerateHex()
    {
        mesh = new Mesh();
        float height = Mathf.Sqrt(3) / 2 * sideLength;

        Vector3[] vertices = new Vector3[]
        {
            new Vector3 (0,0,0), //middle
            new Vector3 (-sideLength / 2,-height,0), //top left
            new Vector3 (sideLength / 2,-height,0), //top right
            new Vector3 (sideLength,0,0), //middle right
            new Vector3 (sideLength/2,height,0), //bottom right
            new Vector3 (-sideLength / 2,height,0), //bottom left
            new Vector3 (-sideLength,0,0) //middle left
        };

        int[] triangles = new int[]
        {
            2,1,0,
            3,2,0,
            4,3,0,
            5,4,0,
            6,5,0,
            1,6,0
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        return mesh;
    }
}
