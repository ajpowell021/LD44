using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileController : MonoBehaviour {

    public Sprite grassSprite;
    public Sprite dirtSprite;
    public GroundType currentGroundType;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void groundHitWithHoe() {
        if (currentGroundType == GroundType.Dirt) {
            currentGroundType = GroundType.Grass;
        }
        else {
            currentGroundType = GroundType.Dirt;
        }
        setSprite();
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
