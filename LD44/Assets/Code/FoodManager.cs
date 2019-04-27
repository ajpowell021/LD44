using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

    public int rawCornAge;
    public int rawCarrotAge;

    public int getAgeFromItemType(ItemType itemType) {
        switch (itemType) {
            case ItemType.Corn:
                return rawCornAge;
            case ItemType.Carrot:
                return rawCarrotAge;
            default:
                Debug.Log("Error: no age data for that item type");
                return 0;
        }
    }
}
