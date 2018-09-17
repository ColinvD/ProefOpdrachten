using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conditions : MonoBehaviour {

    private FieldGenerator generator;
    [SerializeField]
    private List<TileData> mines;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Text text;

	// Use this for initialization
	void Start () {
        mines = new List<TileData>();
        generator = FindObjectOfType<FieldGenerator>();
	}
	
	public void AddMines(TileData mine)
    {
        mines.Add(mine);
    }

    public void WinCondition()
    {
        int count = mines.Count;
        for (int i = 0; i < mines.Count; i++)
        {
            if (mines[i].GetFlagged())
            {
                count--;
            }
        }
        if (count == 0)
        {
            generator.ChangeField();
            panel.SetActive(true);
            text.text = "You won!!!!";
        }
    }

    public void LoseCondition()
    {
        for (int i = 0; i < mines.Count; i++)
        {
            if (mines[i].GetVisable())
            {
                generator.ChangeField();
                panel.SetActive(true);
                text.text = "You Exploded!!!!";
            }
        }
    }
}
