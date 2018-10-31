using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private List<GameObject> panels;

    public void UpdateInventory(List<Item> items)
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if (items.Count>i)
            {
                panels[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(items[i].spriteName);
            }
            else
            {
                panels[i].GetComponent<Image>().sprite = null;
            }
        }
    }
}
