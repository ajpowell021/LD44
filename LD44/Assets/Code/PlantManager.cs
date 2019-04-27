using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour {

    public Sprite cornOne;
    public Sprite cornTwo;
    public Sprite cornThree;

    public Sprite carrotOne;
    public Sprite carrotTwo;
    public Sprite carrotThree;

    public float cornGrowTime;
    public float carrotGrowTime;

    public float cornGrowRate;
    public float carrotGrowRate;

    public float getGrowTimeByPlantType(PlantType type) {
        switch (type) {
            case PlantType.Corn:
                return cornGrowTime;
            case PlantType.Carrot:
                return carrotGrowTime;
            default:
                Debug.Log("No grow time for that plant type");
                return 999;
        }
    }

    public PlantType getPlantTypeFromSeed(ItemType item) {
        switch (item) {
            case ItemType.CornSeed:
                return PlantType.Corn;
            case ItemType.CarrotSeed:
                return PlantType.Carrot;
            default:
                Debug.Log("Invalid item type.  Probably not a plant");
                return PlantType.Corn;
        }
    }

    public Sprite getSpriteByTypeAndLevel(int level, PlantType type) {
        switch (type) {
            case PlantType.Corn:
                switch (level) {
                    case 1:
                        return cornOne;
                    case 2:
                        return cornTwo;
                    default:
                        return cornThree;
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
            default:
                Debug.Log("No sprite present!");
                return cornThree;
        }
    }

    public float getGrowRateFromPlantType(PlantType plantType) {
        switch (plantType) {
            case PlantType.Corn:
                return cornGrowRate;
            case PlantType.Carrot:
                return carrotGrowRate;
            default:
                Debug.Log("No grow rate for that plant type");
                return 0;
        }
    }

    public ItemType getItemTypeFromPlantType(PlantType plantType) {
        switch (plantType) {
            case PlantType.Corn:
                return ItemType.Corn;
            case PlantType.Carrot:
                return ItemType.Carrot;
            default:
                Debug.Log("Error: No matching item type for plant type");
                return ItemType.Corn;
        }
    }
}
