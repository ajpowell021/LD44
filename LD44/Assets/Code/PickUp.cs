using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public ItemType itemType;
    public Vector3 safeSpot;
    
    // Classes
    private PlayerInventory playerInventory;

    private void Awake() {
        safeSpot = new Vector3(0,4,0);
    }

    private void Start() {
        playerInventory = ClassManager.instance.playerInventory;
        checkIfOffMap();
    }

    private void checkIfOffMap() {
        if (transform.position.x > 7) {
            transform.position = safeSpot;
        }
        else if (transform.position.x < -7) {
            transform.position = safeSpot;
        }

        if (transform.position.y > 4) {
            transform.position = safeSpot;
        }
        else if (transform.position.y < -2) {
            transform.position = safeSpot;
        }  
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            playerInventory.attemptPickup(gameObject);
        }
    }
}
