using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputToValue : MonoBehaviour {

    private Data data;

	// Use this for initialization
	void Start () {
        data = FindObjectOfType<Data>();
	}

    public void InputToSize()
    {
        float input = float.Parse(GetComponent<InputField>().text);
        data.SetSize(input);
    }

    public void InputToWidth()
    {
        int input = int.Parse(GetComponent<InputField>().text);
        data.SetWidth(input);
    }

    public void InputToHeight()
    {
        int input = int.Parse(GetComponent<InputField>().text);
        data.SetHeight(input);
    }
}
