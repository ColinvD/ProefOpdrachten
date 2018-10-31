using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour {

    /*[SerializeField]
    private List<Item> items;*/

    [SerializeField]
    private List<Item> inventory;
    private UIManager ui;

    // Use this for initialization
    void Start () {
        ui = GetComponent<UIManager>();
        inventory = new List<Item>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RemoveItem(inventory[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RemoveItem(inventory[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RemoveItem(inventory[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            RemoveItem(inventory[3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            RemoveItem(inventory[4]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            RemoveItem(inventory[5]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            RemoveItem(inventory[6]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            RemoveItem(inventory[7]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            RemoveItem(inventory[8]);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SortItems();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                Debug.Log("Item" + i + ": " + inventory[i]);
            }
        }
    }

    public void AddItem (Item item)
    {
        inventory.Add(item);
        ui.UpdateInventory(inventory);
    }

    public void RemoveItem (Item item)
    {
        inventory.Remove(item);
        ui.UpdateInventory(inventory);
    }

    public void SortItems ()
    {
        List<Item> temp;
        temp = inventory.OrderBy(t => t.GetType().Name).ToList();
        inventory = temp;
        ui.UpdateInventory(inventory);
    }
}
