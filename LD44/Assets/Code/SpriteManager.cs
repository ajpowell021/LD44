using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

    public Sprite noneSprite;
    public Sprite waterCanSprite;
    public Sprite cornSeedSprite;
    public Sprite hoeSprite;
    public Sprite cornSprite;
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
            case ItemType.CornSeed:
                return cornSeedSprite;
            case ItemType.Hoe:
                return hoeSprite;
            case ItemType.Corn:
                return cornSprite;
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
