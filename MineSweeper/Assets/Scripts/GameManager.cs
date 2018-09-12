using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    private FieldGenerator generator;
    private TileData[,] field;

    void Start()
    {
        generator = FindObjectOfType<FieldGenerator>();
        field = generator.GetField();
    }

	public void Flood(TileData currentTile)
    {
        int indexX = 0;
        int indexY = 0;
        for (int i = 0; i < generator.GetLength(); i++)
        {
            for (int j = 0; j < generator.GetHeight(); j++)
            {
                if (field[i,j] == currentTile)
                {
                    indexX = i;
                    indexY = j;
                    i = generator.GetLength();
                    break;
                }
            }
        }
        Vector2 temp;
        temp.x = indexX;
        temp.y = indexY;
        if (Check(temp) == 0)
        {
            for (int i = indexX - 1; i <= indexX + 1; i++)
            {
                for (int j = indexY - 1; j <= indexY + 1; j++)
                {
                    if (i >= 0 && i < generator.GetLength() && j >= 0 && j < generator.GetHeight() && !(i == indexX && j == indexY))
                    {
                        if (field[i, j].GetVisable() == false)
                        {
                            field[i,j].Show();
                        }
                        else
                        {
                            currentTile.ChangeText("0");
                        }
                    }
                }
            }
        }
        else
        {
            string mineCount = "" + Check(temp);
            currentTile.ChangeText(mineCount);
        }
        //Debug.Log(field.Length);
    }

    public int Check(Vector2 tile)
    {
        int mineAmount = 0;
        for (int i = (int)tile.x - 1; i <= (int)tile.x + 1; i++)
        {
            for (int j = (int)tile.y - 1; j <= (int)tile.y + 1; j++)
            {
                if (i >= 0 && i < generator.GetLength() && j >= 0 && j < generator.GetHeight())
                {
                    if (field[i,j].GetMine() == true)
                    {
                        mineAmount++;
                    }
                }
            }
        }
        return mineAmount;
    }
}
