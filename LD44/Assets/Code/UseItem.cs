using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour {

    private PlayerInventory playerInventory;
    private GroundTileManager groundTileManager;
    private SelectedTileController selectedTileController;

    private void Start() {
        playerInventory = ClassManager.instance.playerInventory;
        groundTileManager = ClassManager.instance.groundTileManager;
        selectedTileController = ClassManager.instance.selectedTileController;
    }

    public void useEquippedItem() {
        ItemType item = playerInventory.heldItem;
        GroundTileController controller = groundTileManager.getTileByPosition(selectedTileController.selectedTilePosition);
        
        switch (item) {
            case ItemType.WaterCan:
                break;
            case ItemType.Hoe:
                controller.groundHitWithHoe();
                break;
            case ItemType.CornSeed:
                if (controller.currentGroundType == GroundType.Dirt) {
                    controller.plantSeed(item);    
                }
                break;
            default:
                Debug.Log("Unhandled ItemType in UseItem");
                break;
        }
    }
}
