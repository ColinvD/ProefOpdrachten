using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    [SerializeField]
    private int naam;
    public Item naam2;

    // Use this for initialization
    void Start () {
        switch (naam)
        {
            case 0:
                naam2 = new Apple();
                break;
            case 1:
                naam2 = new Melon();
                break;
            case 2:
                naam2 = new Orange();
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
