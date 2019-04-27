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
    }
}
