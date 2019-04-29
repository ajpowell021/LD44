﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour {

    public Sprite garlicOne;
    public Sprite garlicTwo;
    public Sprite garlicThree;

    public Sprite carrotOne;
    public Sprite carrotTwo;
    public Sprite carrotThree;

    public Sprite potatoOne;
    public Sprite potatoTwo;
    public Sprite potatoThree;

    public Sprite veg4One;
    public Sprite veg4Two;
    public Sprite veg4Three;
    
    public Sprite veg5One;
    public Sprite veg5Two;
    public Sprite veg5Three;

    public float garlicGrowRate;
    public float carrotGrowRate;
    public float potatoGrowRate;
    public float veg4GrowRate;
    public float veg5GrowRate;

    public float wateredMultiplier;
    public float wateredLastsTime;

    public PlantType getPlantTypeFromSeed(ItemType item) {
        switch (item) {
            case ItemType.GarlicSeed:
                return PlantType.Garlic;
            case ItemType.CarrotSeed:
                return PlantType.Carrot;
            default:
                Debug.Log("Invalid item type.  Probably not a plant");
                return PlantType.Garlic;
        }
    }

    public Sprite getSpriteByTypeAndLevel(int level, PlantType type) {
        switch (type) {
            case PlantType.Garlic:
                switch (level) {
                    case 1:
                        return garlicOne;
                    case 2:
                        return garlicTwo;
                    default:
                        return garlicThree;
                }
            case PlantType.Carrot:
                switch (level) {
                    case 1:
                        return carrotOne;
                    case 2:
                        return carrotTwo;
                    default:
                        return carrotThree;
                }
            case PlantType.Potato:
                switch (level) {
                    case 1:
                        return potatoOne;
                    case 2:
                        return potatoTwo;
                    default:
                        return potatoThree;
                }
            case PlantType.Veg4:
                switch (level) {
                    case 1:
                        return veg4One;
                    case 2:
                        return veg4Two;
                    default:
                        return veg4Three;
                }
            case PlantType.Veg5:
                switch (level) {
                    case 1:
                        return veg5One;
                    case 2:
                        return veg5Two;
                    default:
                        return veg5Three;
                }
            default:
                Debug.Log("No sprite present!");
                return garlicThree;
        }
    }

    public float getGrowRateFromPlantType(PlantType plantType) {
        switch (plantType) {
            case PlantType.Garlic:
                return garlicGrowRate;
            case PlantType.Carrot:
                return carrotGrowRate;
            case PlantType.Potato:
                return potatoGrowRate;
            case PlantType.Veg4:
                return veg4GrowRate;
            case PlantType.Veg5:
                return veg5GrowRate;
            default:
                Debug.Log("No grow rate for that plant type");
                return 0;
        }
    }

    public ItemType getItemTypeFromPlantType(PlantType plantType) {
        switch (plantType) {
            case PlantType.Garlic:
                return ItemType.Garlic;
            case PlantType.Carrot:
                return ItemType.Carrot;
            case PlantType.Potato:
                return ItemType.Potatoe;
            case PlantType.Veg4:
                return ItemType.Veg4;
            case PlantType.Veg5:
                return ItemType.Veg5;
            default:
                Debug.Log("Error: No matching item type for plant type");
                return ItemType.Garlic;
        }
    }
}
