using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour {

    private PlayerInventory playerInventory;
    private GroundTileManager groundTileManager;
    private SelectedTileController selectedTileController;
    private PlantManager plantManager;

    private void Start() {
        playerInventory = ClassManager.instance.playerInventory;
        groundTileManager = ClassManager.instance.groundTileManager;
        selectedTileController = ClassManager.instance.selectedTileController;
        plantManager = ClassManager.instance.plantManager;
    }

    public void useEquippedItem() {
        ItemType item = playerInventory.heldItem;
        GroundTileController controller = groundTileManager.getTileByPosition(selectedTileController.selectedTilePosition);
        
        switch (item) {
            case ItemType.WaterCan:
                if (controller.currentGroundType == GroundType.Dirt) {
                    controller.plant.waterGround();
                }
                break;
            case ItemType.Hoe:
                controller.groundHitWithHoe();
                break;
            case ItemType.CornSeed:
                if (controller.currentGroundType == GroundType.Dirt && !controller.plant.seedPresent) {
                    controller.plantSeed(item);
                    playerInventory.deleteInventoryItem();
                }
                break;
            case ItemType.None:
                if (controller.plant.canBePicked) {
                    playerInventory.setNewInventoryItem(plantManager.getItemTypeFromPlantType(controller.plant.plantType));
                    controller.plant.pickPlant();
                }
                break;
            default:
                Debug.Log("Unhandled ItemType in UseItem");
                break;
        }
    }
}
