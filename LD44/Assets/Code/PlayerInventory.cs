using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public ItemType heldItem = ItemType.None;

    public void setNewInventoryItem(ItemType newItem) {
        heldItem = newItem;
        // Do art stuff
    }

    public void dropInventoryItem() {
        heldItem = ItemType.None;
        // Do art stuff.
    }

    public void attemptPickup(GameObject item) {
        if (heldItem == ItemType.None) {
            setNewInventoryItem(item.GetComponent<PickUp>().itemType);
            Destroy(item);
        }
    }
    
}
