using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //-----------------------------
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFilled;
    public string itemDescription;
    //-----------------------------
    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private InventoryManager inventoryManager;
    [SerializeField]
    public GameObject selectedShader;
    [SerializeField]
    private int maxNumberOfStack;
    [SerializeField]
    private Sprite emptySprite;

    public bool isItemSelected;
    //-----------------------------
    public Image descItemImage;
    public TMP_Text descItemNameText;
    public TMP_Text descItemText;
    

    private void Awake()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }


    public int Additem(string itemName, int quantity, Sprite itemSprite, string desctription)
    {
        if (isFilled)
        {
            return quantity;
        }
        
        this.itemName = itemName;
        
        this.itemSprite = itemSprite;
        this.itemDescription = desctription;
        itemImage.sprite = itemSprite;

        this.quantity += quantity;
        if (this.quantity >= maxNumberOfStack)
        {
            quantityText.text = maxNumberOfStack.ToString();
            quantityText.enabled = true;
            isFilled = true;

            int extraItems = this.quantity - maxNumberOfStack;
            this.quantity = maxNumberOfStack;
            return extraItems;
        }

        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;

    }

    public void OnPointerClick(PointerEventData eventData) // 클릭되면 발동됨
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    private void OnLeftClick()
    {
        if (isItemSelected && this.quantity > 0)
        {
            inventoryManager.UseItem(itemName);
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
            {
                EmptySlot();
            }
        }
        else
        {
            inventoryManager.DeSelectAllSlots();
            selectedShader.SetActive(true);
            isItemSelected = true;
            descItemNameText.text = itemName;
            descItemText.text = itemDescription;
            descItemImage.sprite = itemSprite;
            if (descItemImage.sprite == null)
            {
                descItemImage.sprite = null;
            }
        }
    }

    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = null;
        descItemNameText.text = "";
        descItemText.text = "";
        descItemImage.sprite = null;

    }

    private void OnRightClick()
    {
        
    }
}
