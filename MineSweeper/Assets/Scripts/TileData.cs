using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileData : MonoBehaviour {

    public bool visable = false;
    public bool mine = false;
    public bool flagged = false;
    private Text number;
    private GameManager manager;
    private MineCounter counter;
    [SerializeField]
    private Conditions condition;
    [SerializeField]
    private Sprite[] typeImage;

	// Use this for initialization
	void Start () {
        number = GetComponentInChildren<Text>();
        number.text = "";
        manager = FindObjectOfType<GameManager>();
        counter = FindObjectOfType<MineCounter>();
        condition = FindObjectOfType<Conditions>();
    }

    public void Show()
    {
        if (!Input.GetKey(KeyCode.LeftShift) && !flagged)
        {
            visable = true;
            if (mine == false)
            {
                GetComponent<Image>().color = Color.green;
                manager.Flood(this);
            }
            else if (mine == true)
            {
                GetComponent<Image>().sprite = typeImage[2];
                condition.LoseCondition();
            }
        } else if(Input.GetKey(KeyCode.LeftShift) && !visable)
        {
            Flag();
        }
    }

    public void Dead()
    {
        visable = true;
        if (mine == false)
        {
            GetComponent<Image>().color = Color.green;
        }
        else if (mine == true)
        {
            GetComponent<Image>().sprite = typeImage[2];
        }
    }

    private void Flag()
    {
        flagged = !flagged;
        if (flagged)
        {
            GetComponent<Image>().sprite = typeImage[1];
            counter.ChangeCounter(-1);
        }
        else
        {
            GetComponent<Image>().sprite = typeImage[0];
            counter.ChangeCounter(1);
        }
    }

    public void ChangeVisable(bool value)
    {
        visable = value;
    }

    public void ChangeMine(bool value)
    {
        mine = value;
    }

    public void ChangeFlagged(bool value)
    {
        flagged = value;
    }

    public bool GetVisable()
    {
        return visable;
    }

    public bool GetMine()
    {
        return mine;
    }

    public bool GetFlagged()
    {
        return flagged;
    }

    public void ChangeText(string text)
    {
        number.text = text;
    }
}
