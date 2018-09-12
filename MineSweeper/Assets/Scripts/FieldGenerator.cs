using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldGenerator : MonoBehaviour {

    private TileData[,] field;
    [SerializeField]
    private int length;
    [SerializeField]
    private int height;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private int mines;
    private Conditions conditions;

    // Use this for initialization
    void Start () {
        conditions = FindObjectOfType<Conditions>();
        if (mines < length * height && mines > 0)
        {
            field = new TileData[length, height];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    field[i, j] = Instantiate(tile, canvas.transform).GetComponent<TileData>();
                    field[i, j].gameObject.transform.position = new Vector2(canvas.transform.position.x - length * 25 + i * 50, canvas.transform.position.y + height * 24 - j * 50);
                }
            }

            for (int i = 0; i < mines; i++)
            {
                int x = Random.Range(0, length - 1);
                int y = Random.Range(0, height - 1);
                if (!field[x, y].GetMine())
                {
                    //bomb true
                    field[x, y].ChangeMine(true);
                    conditions.AddMines(field[x, y]);
                }
                else
                {
                    i--;
                }
            }
        }
	}

    /*public void ChangeField()
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < height; j++)
            {
                field[i, j].Dead();
            }
        }
    }*/

    public TileData[,] GetField()
    {
        return field;
    }

    public int GetMines()
    {
        return mines;
    }

    public int GetLength()
    {
        return length;
    }

    public int GetHeight()
    {
        return height;
    }
}
