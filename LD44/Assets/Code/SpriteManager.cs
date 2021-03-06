﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

    public Sprite noneSprite;
    public Sprite waterCanSprite;
    public Sprite garlicSeedSprite;
    public Sprite garlicSprite;
    public Sprite carrotSeedSprite;
    public Sprite carrotSprite;
    public Sprite potatoSeedSprite;
    public Sprite potatoSprite;
    public Sprite pepperSeedSprite;
    public Sprite pepperSprite;
    public Sprite chickpeaSeedSprite;
    public Sprite chickpeaSprite;
    public Sprite hoeSprite;
    public Sprite recipeOneSprite;
    public Sprite recipeTwoSprite;
    public Sprite recipeThreeSprite;
    public Sprite recipeFourSprite;
    public Sprite recipeFiveSprite;

    public Sprite getSpriteByItemType(ItemType itemType) {
        switch (itemType) {
            case ItemType.None:
                return noneSprite;
            case ItemType.WaterCan:
                return waterCanSprite;
            case ItemType.Hoe:
                return hoeSprite;
            case ItemType.GarlicSeed:
                return garlicSeedSprite;
            case ItemType.Garlic:
                return garlicSprite;
            case ItemType.CarrotSeed:
                return carrotSeedSprite;
            case ItemType.Carrot:
                return carrotSprite;
            case ItemType.PotatoeSeed:
                return potatoSeedSprite;
            case ItemType.Potatoe:
                return potatoSprite;
            case ItemType.PepperSeed:
                return pepperSeedSprite;
            case ItemType.Pepper:
                return pepperSprite;
            case ItemType.ChickpeaSeed:
                return chickpeaSeedSprite;
            case ItemType.Chickpea:
                return chickpeaSprite;
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
            default:
                Debug.Log("Unrecognized sprite in getSprite;");
                return waterCanSprite;
        }
    }
}
