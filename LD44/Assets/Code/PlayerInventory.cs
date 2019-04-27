using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    public ItemType heldItem = ItemType.None;
    public Image equippedItemImage;
    
    // Classes
    private SpriteManager spriteManager;
    private DropItem dropItem;

    private void Start() {
        spriteManager = ClassManager.instance.spriteManager;
        dropItem = ClassManager.instance.dropItem;
    }

    public void setNewInventoryItem(ItemType newItem) {
        heldItem = newItem;
        equippedItemImage.sprite = spriteManager.getSpriteByItemType(newItem);
    }

    public void dropInventoryItem() {
        dropItem.itemDropped(heldItem);
        heldItem = ItemType.None;
        equippedItemImage.sprite = spriteManager.getSpriteByItemType(ItemType.None);
    }

    public void deleteInventoryItem() {
        heldItem = ItemType.None;
        equippedItemImage.sprite = spriteManager.getSpriteByItemType(ItemType.None);
    }

    public void attemptPickup(GameObject item) {
        if (heldItem == ItemType.None) {
            setNewInventoryItem(item.GetComponent<PickUp>().itemType);
            Destroy(item);
        }
    }
    
}
