using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

    public Sprite noneSprite;
    public Sprite waterCanSprite;
    public Sprite cornSeedSprite;
    public Sprite cornSprite;
    public Sprite carrotSeedSprite;
    public Sprite carrotSprite;
    public Sprite potatoSeedSprite;
    public Sprite potatoSprite;
    public Sprite veg4SeedSprite;
    public Sprite veg4Sprite;
    public Sprite veg5SeedSprite;
    public Sprite veg5Sprite;
    public Sprite hoeSprite;
    public Sprite recipeOneSprite;
    public Sprite recipeTwoSprite;
    public Sprite recipeThreeSprite;
    public Sprite recipeFourSprite;
    public Sprite recipeFiveSprite;
    public Sprite recipeSixSprite;

    public Sprite getSpriteByItemType(ItemType itemType) {
        switch (itemType) {
            case ItemType.None:
                return noneSprite;
            case ItemType.WaterCan:
                return waterCanSprite;
            case ItemType.Hoe:
                return hoeSprite;
            case ItemType.CornSeed:
                return cornSeedSprite;
            case ItemType.Corn:
                return cornSprite;
            case ItemType.CarrotSeed:
                return carrotSeedSprite;
            case ItemType.Carrot:
                return carrotSprite;
            case ItemType.PotatoeSeed:
                return potatoSeedSprite;
            case ItemType.Potatoe:
                return potatoSprite;
            case ItemType.Veg4Seed:
                return veg4SeedSprite;
            case ItemType.Veg4:
                return veg4Sprite;
            case ItemType.Veg5Seed:
                return veg5SeedSprite;
            case ItemType.Veg5:
                return veg5Sprite;
            case ItemType.RecipeOne:
                return recipeOneSprite;
            case ItemType.RecipeTwo:
                return recipeTwoSprite;
            case ItemType.RecipeThree:
                return recipeThreeSprite;
            case ItemType.RecipeFour:
                return recipeFourSprite;
            case ItemType.RecipeFive:
                return recipeFiveSprite;
            case ItemType.RecipeSix:
                return recipeSixSprite;
            default:
                Debug.Log("Unrecognized sprite in getSprite;");
                return waterCanSprite;
        }
    }
}
