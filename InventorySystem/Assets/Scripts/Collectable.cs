using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    [SerializeField]
    private int itemNumber;
    public Item currentItem;

    // Use this for initialization
    void Start () {
        switch (itemNumber)
        {
            case 0:
                currentItem = new Apple();
                break;
            case 1:
                currentItem = new Melon();
                break;
            case 2:
                currentItem = new Orange();
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
