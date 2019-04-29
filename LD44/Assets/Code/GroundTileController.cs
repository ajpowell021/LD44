using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileController : MonoBehaviour {

    public GroundType currentGroundType;
    public Plant plant;
    private float currentTimeToGrass;
    private bool countToGrass;
    public bool dontChange;

    private GroundTileManager groundTileManager;
    
    private void Awake() {
        plant = gameObject.GetComponent<Plant>();
    }

    private void Start() {
        groundTileManager = ClassManager.instance.groundTileManager;
    }

    private void Update() {
        if (countToGrass) {
            currentTimeToGrass += Time.deltaTime;
            if (currentTimeToGrass > groundTileManager.returnToGrassTime) {
                currentGroundType = GroundType.Grass;
                groundTileManager.setAllGroundSprites();
                currentTimeToGrass = 0;
                countToGrass = false;
            }
        }
    }

    public void groundHitWithHoe() {
        if (currentGroundType == GroundType.Dirt && !plant.seedPresent) {
            currentGroundType = GroundType.Grass;
            groundTileManager.setAllGroundSprites();
        }
        else {
            currentGroundType = GroundType.Dirt;
            groundTileManager.setAllGroundSprites();
            countToGrass = true;
        }
    }

    public void plantSeed(ItemType seedType) {
        plant.plantPlant(seedType);
        countToGrass = false;
        currentTimeToGrass = 0;
    }

    public void startCountToGrassTimer() {
        // Pick a plant.
        countToGrass = true;
        currentTimeToGrass = 0;
    }
    
    
}
