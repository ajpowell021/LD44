using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

    public Sprite noneSprite;
    public Sprite waterCanSprite;
    public Sprite cornSeedSprite;
    public Sprite hoeSprite;
    public Sprite cornSprite;

    public Sprite getSpriteByItemType(ItemType itemType) {
        switch (itemType) {
            case ItemType.None:
                return noneSprite;
            case ItemType.WaterCan:
                return waterCanSprite;
            case ItemType.CornSeed:
                return cornSeedSprite;
            case ItemType.Hoe:
                return hoeSprite;
            case ItemType.Corn:
                return cornSprite;
            default:
                Debug.Log("Unrecognized sprite in getSprite;");
                return waterCanSprite;
        }
    }
}
