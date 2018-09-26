using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conditions : MonoBehaviour {

    private FieldGenerator generator;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Text text;

	// Use this for initialization
	void Start () {
        generator = FindObjectOfType<FieldGenerator>();
	}

    public void WinCondition()
    {
        Debug.Log("win");
        generator.ChangeField();
        panel.SetActive(true);
        text.text = "You won!!!!";
    }

    public void LoseCondition()
    {
        Debug.Log("lose");
        generator.ChangeField();
        panel.SetActive(true);
        text.text = "You Exploded!!!!";
    }
}
