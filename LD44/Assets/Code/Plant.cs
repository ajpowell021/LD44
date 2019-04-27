using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {

    public PlantType plantType;
    public float currentGrowPercentage;
    public float timeToGrow;
    public float growRate;
    public Sprite plantSprite;
    public int plantLevel;
    private bool growing;
    public bool canBePicked;
    public bool seedPresent;

    private SpriteRenderer spriteRenderer;
    private PlantManager plantManager;

    private void Awake() {
        spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Start() {
        plantManager = ClassManager.instance.plantManager;
    }

    private void Update() {
        if (growing) {
            growPlant();
        }
    }

    public void plantPlant(ItemType itemType) {
        plantType = plantManager.getPlantTypeFromSeed(itemType);
        plantLevel = 1;
        setPlantSprite();
        timeToGrow = plantManager.getGrowTimeByPlantType(plantType);
        growRate = plantManager.getGrowRateFromPlantType(plantType);
        growing = true;
        seedPresent = true;
    }

    public void pickPlant() {
        plantLevel = 0;
        plantSprite = null;
        spriteRenderer.sprite = null;
        canBePicked = false;
        seedPresent = false;
        currentGrowPercentage = 0;
    }

    private void growPlant() {
        currentGrowPercentage += Time.deltaTime * growRate;
        if (currentGrowPercentage > 50 && currentGrowPercentage < 52) {
            plantLevel = 2;
            setPlantSprite();
        }
        else if (currentGrowPercentage > 100) {
            plantLevel = 3;
            setPlantSprite();
            canBePicked = true;
            growing = false;
        }
    }

    private void setPlantSprite() {
        plantSprite = plantManager.getSpriteByTypeAndLevel(plantLevel, plantType);
        spriteRenderer.sprite = plantSprite;
    }
}
