using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

   public InputMode currentInputMode;
   
   // Classes
   private FarmerMovement farmerMovement;
   private PlayerInventory playerInventory;
   private FoodManager foodManager;
   private UseItem useItem;
   private ShopManager shopManager;

   private void Start() {
      farmerMovement = ClassManager.instance.farmerMovement;
      playerInventory = ClassManager.instance.playerInventory;
      foodManager = ClassManager.instance.foodManager;
      useItem = ClassManager.instance.useItem;
      shopManager = ClassManager.instance.shopManager;
   }

   public IEnumerator changeInputMode(InputMode newMode) {
      yield return new WaitForEndOfFrame();
      currentInputMode = newMode;
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
      else if (currentInputMode == InputMode.RecipeMenu) {
         if (Input.GetKeyDown(KeyCode.Escape)) {
            foodManager.toggleRecipePanel();
         }

         if (Input.GetKeyDown(KeyCode.Space)) {
            foodManager.executeSelectedAction();
         }

         if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            foodManager.adjustSelectedRecipeIndex(1);
         }
         else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            foodManager.adjustSelectedRecipeIndex(-1);
         }
      }
      else if (currentInputMode == InputMode.ShopMenu) {
         if (Input.GetKeyDown(KeyCode.Escape)) {
            shopManager.toggleShopPanel();
         }

         if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            shopManager.moveSelector(-1);
         }
         else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            shopManager.moveSelector(1);
         }

         if (Input.GetKeyDown(KeyCode.Space)) {
            shopManager.makeSelection();
         }
      }
   }
}
