using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {

    private PrefabManager prefabManager;
    private FarmerMovement farmerMovement;

    private void Start() {
        prefabManager = ClassManager.instance.prefabManager;
        farmerMovement = ClassManager.instance.farmerMovement;
    }

    public void itemDropped(ItemType item) {
        Vector3 positionToDrop = farmerMovement.currentFacingDirection * -1.5f + farmerMovement.gameObject.transform.position;
        Instantiate(prefabManager.getObjectByItemType(item), positionToDrop, Quaternion.identity);   
    }
}
