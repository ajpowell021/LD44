using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileController : MonoBehaviour {

    public Sprite grassSprite;
    public Sprite dirtSprite;
    public GroundType currentGroundType;
    public Plant plant;

    private SpriteRenderer spriteRenderer;
    private GroundTileManager groundTileManager;
    
    private void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        plant = gameObject.GetComponent<Plant>();
    }

    private void Start() {
        groundTileManager = ClassManager.instance.groundTileManager;
    }

    public void groundHitWithHoe() {
        if (currentGroundType == GroundType.Dirt && !plant.seedPresent) {
            currentGroundType = GroundType.Grass;
            groundTileManager.setAllGroundSprites();
        }
        else {
            currentGroundType = GroundType.Dirt;
            groundTileManager.setAllGroundSprites();
        }
    }

    public void plantSeed(ItemType seedType) {
        plant.plantPlant(seedType);
    }

    private void setSprite() {
        if (currentGroundType == GroundType.Dirt) {
            spriteRenderer.sprite = dirtSprite;
        }
        else {
            spriteRenderer.sprite = grassSprite;
        }
    }
}
