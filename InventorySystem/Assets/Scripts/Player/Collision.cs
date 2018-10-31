using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    private Inventory inventory;
	// Use this for initialization
	void Start () {
        inventory = FindObjectOfType<Inventory>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            inventory.AddItem(other.GetComponent<Collectable>().naam2);
        }
    }
}
