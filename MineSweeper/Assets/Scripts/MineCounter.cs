using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineCounter : MonoBehaviour {

    [SerializeField]
    private Text counterText;
    private FieldGenerator generator;
    private int minesCount;
    private Conditions condition;

	// Use this for initialization
	void Start () {
        generator = FindObjectOfType<FieldGenerator>();
        condition = FindObjectOfType<Conditions>();
        minesCount = generator.GetMines();
        counterText.text = "Mines left: " + minesCount;
	}
	
	public void ChangeCounter(int amount)
    {
        minesCount += amount;
        counterText.text = "Mines left: " + minesCount;
        if (minesCount == 0)
        {
            condition.WinCondition();
        }
    }
}
