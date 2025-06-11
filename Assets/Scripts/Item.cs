using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private Sprite sprite;
    [SerializeField,TextArea]
    private string desctription;

    private InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, desctription);
            if (leftOverItems <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                quantity = leftOverItems;
            }
        }
    }



}
