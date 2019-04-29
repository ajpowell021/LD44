using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

    public GameObject waterCanObject;
    public GameObject grassObject;
    public GameObject hoeObject;
    
    public GameObject garlicSeedObject;
    public GameObject garlicObject;

    public GameObject carrotSeedObject;
    public GameObject carrotObject;

    public GameObject potatoSeedObject;
    public GameObject potatoObject;

    public GameObject pepperSeedObject;
    public GameObject pepperObject;

    public GameObject veg5SeedObject;
    public GameObject veg5Object;

    public GameObject recipeOneObject;
    public GameObject recipeTwoObject;
    public GameObject recipeThreeObject;
    public GameObject recipeFourObject;
    public GameObject recipeFiveObject;
    public GameObject recipeSixObject;

//    private void Awake() {
//        for (int i = -10; i < 11; i++) {
//            for (int j = -4; j < 6; j++) {
//                Instantiate(grassObject, new Vector3(i, j, 0), Quaternion.identity);
//            }
//        }
//    }

    public GameObject getObjectByItemType(ItemType item) {
        switch (item) {
            case ItemType.WaterCan:
                return waterCanObject;
            case ItemType.Hoe:
                return hoeObject;
            case ItemType.GarlicSeed:
                return garlicSeedObject;
            case ItemType.Garlic:
                return garlicObject;
            case ItemType.CarrotSeed:
                return carrotSeedObject;
            case ItemType.Carrot:
                return carrotObject;
            case ItemType.PotatoeSeed:
                return potatoSeedObject;
            case ItemType.Potatoe:
                return potatoObject;
            case ItemType.PepperSeed:
                return pepperSeedObject;
            case ItemType.Pepper:
                return pepperObject;
            case ItemType.Veg5Seed:
                return veg5SeedObject;
            case ItemType.Veg5:
                return veg5Object;
            case ItemType.RecipeOne:
                return recipeOneObject;
            case ItemType.RecipeTwo:
                return recipeTwoObject;
            case ItemType.RecipeThree:
                return recipeThreeObject;
            case ItemType.RecipeFour:
                return recipeFourObject;
            case ItemType.RecipeFive:
                return recipeFiveObject;
            case ItemType.RecipeSix:
                return recipeSixObject;
            default:
                Debug.Log("Asked for game object for non existing item type.");
                return null;
        }
    }
}
