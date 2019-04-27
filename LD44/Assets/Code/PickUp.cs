using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public ItemType itemType;
    
    // Classes
    private PlayerInventory playerInventory;

    private void Start() {
        playerInventory = ClassManager.instance.playerInventory;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            playerInventory.attemptPickup(gameObject);
        }
    }
}
