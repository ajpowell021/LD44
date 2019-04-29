using System.Collections;
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

    public Sprite pepperOne;
    public Sprite pepperTwo;
    public Sprite pepperThree;
    
    public Sprite chickpeaOne;
    public Sprite chickpeaTwo;
    public Sprite chickpeaThree;

    public float garlicGrowRate;
    public float carrotGrowRate;
    public float potatoGrowRate;
    public float pepperGrowRate;
    public float chickpeaGrowRate;

    public float wateredMultiplier;
    public float wateredLastsTime;

    public PlantType getPlantTypeFromSeed(ItemType item) {
        switch (item) {
            case ItemType.GarlicSeed:
                return PlantType.Garlic;
            case ItemType.CarrotSeed:
                return PlantType.Carrot;
            case ItemType.PotatoeSeed:
                return PlantType.Potato;
            case ItemType.PepperSeed:
                return PlantType.Pepper;
            case ItemType.ChickpeaSeed:
                return PlantType.ChickPea;
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
            case PlantType.Pepper:
                switch (level) {
                    case 1:
                        return pepperOne;
                    case 2:
                        return pepperTwo;
                    default:
                        return pepperThree;
                }
            case PlantType.ChickPea:
                switch (level) {
                    case 1:
                        return chickpeaOne;
                    case 2:
                        return chickpeaTwo;
                    default:
                        return chickpeaThree;
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
            case PlantType.Pepper:
                return pepperGrowRate;
            case PlantType.ChickPea:
                return chickpeaGrowRate;
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
            case PlantType.Pepper:
                return ItemType.Pepper;
            case PlantType.ChickPea:
                return ItemType.Chickpea;
            default:
                Debug.Log("Error: No matching item type for plant type");
                return ItemType.Garlic;
        }
    }
}
