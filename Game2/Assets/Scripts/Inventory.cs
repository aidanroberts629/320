using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<string> items;

    public void AddItem(string itemName)
    {
        if (items.Count < 3) items.Add(itemName);

        foreach (var n in items)
        {
            Debug.Log(n);
        }
    }

    public void ClearInventory()
    {
        items.Clear();
    }


}
