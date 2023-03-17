using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
    //=======ITEM DATA=======//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public ItemType itemType;

    //=======ITEM SLOT=======//
    [SerializeField] private Image itemImage;

    //=======EQUIPPED SLOTS=======//
    [SerializeField] private EquippedSlot headSlot, cloakSlot, bodySlot, legsSlot, mainHandSlot, offHandSlot, relicSlot, feetSlot; 


    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        if (isFull)
        {
            return quantity;
        }
        this.itemType = itemType;
        this.itemName = itemName;
        this.quantity = 1;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
        this.itemDescription = itemDescription;
        isFull = true;
        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            EquipGear();
        }
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
    }

    private void EquipGear()
    {
        if (itemType == ItemType.head)
        {
            headSlot.EquipGear(itemSprite, itemName, itemDescription);
        } 
        else if (itemType == ItemType.cloak)
        {
            cloakSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.body)
        {
            bodySlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.legs)
        {
            legsSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.mainHand)
        {
            mainHandSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.offHand)
        {
            offHandSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.relic)
        {
            relicSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.feet)
        {
            feetSlot.EquipGear(itemSprite, itemName, itemDescription);
        }

        EmptySlot();
    }

    private void EmptySlot()
    {
        itemImage.enabled = false;
        quantity = 0;
        isFull = false;
    }

    public void OnRightClick()
    {

    }
}
