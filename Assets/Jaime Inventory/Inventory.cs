using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public Sprite itemImage = null;

    public void AddItem(Sprite itemToAdd)
    {
        itemImage = itemToAdd;
    }


    public void RemoveItem(Sprite itemToRemove)
    {
        itemImage = null;
    }
}
