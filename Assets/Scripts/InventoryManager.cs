using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{

    public ItemSlot[] itemSlot;
    public ItemData[] itemDatas;


    public void UseItem(string itemName)
    {
        for (int i = 0; i < itemDatas.Length; i++)
        {
            if (itemName == itemDatas[i].itemName)
            {
                itemDatas[i].UseItem();
            }
        
        }
    
    
    }
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string description)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFilled == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].Additem(itemName,quantity,itemSprite, description);
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, quantity, itemSprite, description);
                }
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeSelectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].isItemSelected = false;
        }
    }
}
