using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

   public InputMode currentInputMode;
   
   // Classes
   private FarmerMovement farmerMovement;
   private PlayerInventory playerInventory;
   private UseItem useItem;

   private void Start() {
      farmerMovement = ClassManager.instance.farmerMovement;
      playerInventory = ClassManager.instance.playerInventory;
      useItem = ClassManager.instance.useItem;
   }

   private void Update() {

      if (currentInputMode == InputMode.Play) {
         if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            farmerMovement.move(Vector3.up);
         }

         if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            farmerMovement.move(Vector3.down);
         }
      
         if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            farmerMovement.move(Vector3.left);
         }
      
         if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            farmerMovement.move(Vector3.right);
         }

         if (Input.GetKeyDown(KeyCode.Space)) {
            useItem.useEquippedItem();
         }

         if (Input.GetKeyDown(KeyCode.Z)) {
            playerInventory.dropInventoryItem();
         }
      }
   }
}
