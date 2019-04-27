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

        switch (item) {
            case ItemType.WaterCan:
                break;
            case ItemType.Hoe:
                GroundTileController controller = groundTileManager.getTileByPosition(selectedTileController.selectedTilePosition);
                controller.groundHitWithHoe();
                break;
            case ItemType.CornSeed:
                break;
            default:
                Debug.Log("Unhandled ItemType in UseItem");
                break;
        }
    }
}
