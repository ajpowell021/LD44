using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassManager : MonoBehaviour {

    public static ClassManager instance;

    public GameObject farmerObject;
    
    // Classes
    public InputManager inputManager;
    public AgeManager ageManager;
    public FarmerMovement farmerMovement;
    public PlayerInventory playerInventory;
    public SpriteManager spriteManager;
    public PrefabManager prefabManager;
    public DropItem dropItem;
    public SelectedTileController selectedTileController;
    public UseItem useItem;
    public GroundTileManager groundTileManager;
    public PlantManager plantManager;
    public FoodManager foodManager;
    
    private void Awake() {
        setInstance();
        setClasses();
    }

    private void setInstance() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }

    private void setClasses() {
        inputManager = gameObject.GetComponent<InputManager>();
        ageManager = gameObject.GetComponent<AgeManager>();
        farmerMovement = farmerObject.GetComponent<FarmerMovement>();
        playerInventory = farmerObject.GetComponent<PlayerInventory>();
        spriteManager = gameObject.GetComponent<SpriteManager>();
        prefabManager = gameObject.GetComponent<PrefabManager>();
        dropItem = farmerObject.GetComponent<DropItem>();
        selectedTileController = farmerObject.GetComponent<SelectedTileController>();
        useItem = farmerObject.GetComponent<UseItem>();
        groundTileManager = gameObject.GetComponent<GroundTileManager>();
        plantManager = gameObject.GetComponent<PlantManager>();
        foodManager = gameObject.GetComponent<FoodManager>();
    }
}
