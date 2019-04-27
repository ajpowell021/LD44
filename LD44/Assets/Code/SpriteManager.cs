using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

    public Sprite noneSprite;
    public Sprite waterCanSprite;
    public Sprite cornSeedSprite;

    public Sprite getSpriteByItemType(ItemType itemType) {
        switch (itemType) {
            case ItemType.None:
                return noneSprite;
            case ItemType.WaterCan:
                return waterCanSprite;
            case ItemType.CornSeed:
                return cornSeedSprite;
            default:
                Debug.Log("Unrecognized sprite in getSprite;");
                return waterCanSprite;
        }
    }
}
