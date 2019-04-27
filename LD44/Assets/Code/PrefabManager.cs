using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

    public GameObject waterCanObject;
    public GameObject cornSeedObject;
    public GameObject grassObject;
    public GameObject hoeObject;

//    private void Awake() {
//        for (int i = -10; i < 10; i++) {
//            for (int j = -4; j < 5; j++) {
//                Instantiate(grassObject, new Vector3(i, j, 0), Quaternion.identity);
//            }
//        }
//    }

    public GameObject getObjectByItemType(ItemType item) {
        switch (item) {
            case ItemType.WaterCan:
                return waterCanObject;
            case ItemType.CornSeed:
                return cornSeedObject;
            case ItemType.Hoe:
                return hoeObject;
            default:
                Debug.Log("Asked for game object for non existing item type.");
                return null;
        }
    }
}
