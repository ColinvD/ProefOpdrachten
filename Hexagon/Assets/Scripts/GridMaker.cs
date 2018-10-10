using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour {

    [SerializeField]
    private GameObject hexagon;
    private MakeMesh MeshMaker;
    private Data data;
    private Mesh hexMesh;
    private int width = 2;
    private int height = 2;
    private GameObject[,] field;

    void Start()
    {
        data = FindObjectOfType<Data>();
        MeshMaker = GetComponent<MakeMesh>();
        hexMesh = MeshMaker.GenerateHex();
    }

    public void MakeGrid()
    {
        if (field != null)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Destroy(field[i, j]);
                }
            }
        }
        width = data.GetWidth();
        height = data.GetHeight();
        field = new GameObject[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                field[i, j] = Instantiate(hexagon, new Vector3(0+i*1.5f*data.GetSize(),0+j*Mathf.Sqrt(3) * data.GetSize() + i % 2 * Mathf.Sqrt(3) / 2 * data.GetSize(),0), new Quaternion());
                field[i, j].GetComponent<MeshFilter>().mesh = hexMesh;
                field[i, j].transform.localScale = new Vector3(0.95f,0.95f,0.95f) * data.GetSize();
            }
        }
    }
}
