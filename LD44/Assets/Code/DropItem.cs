using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {

    private PrefabManager prefabManager;

    private void Start() {
        prefabManager = ClassManager.instance.prefabManager;
    }

    public void itemDropped(ItemType item) {
        int roll = Random.Range(0, 2);
        Vector3 positionToDrop;
        if (roll == 0) {
            positionToDrop = transform.position + new Vector3(-3, 0, 0);
        }
        else {
            positionToDrop = transform.position + new Vector3(3, 0, 0);
        }
        Instantiate(prefabManager.getObjectByItemType(item), positionToDrop, Quaternion.identity);
    }
}
