using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

    public GameObject waterCanObject;
    public GameObject cornSeedObject;
    public GameObject grassObject;
    public GameObject hoeObject;

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
