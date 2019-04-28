using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilledGroundArtSetter : MonoBehaviour {
     // Sprites
    public Sprite allOpen;
    
    public Sprite topOpen;
    public Sprite bottomOpen;
    public Sprite leftOpen;
    public Sprite rightOpen;

    public Sprite topLeftOpen;
    public Sprite topRightOpen;
    public Sprite bottomLeftOpen;
    public Sprite bottomRightOpen;

    public Sprite allClosed;

    private SpriteRenderer spriteRenderer;
    private GroundTileManager groundTileManager;

    private void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start() {
        groundTileManager = ClassManager.instance.groundTileManager;
    }

    public void detectAndSetSprite() {
        Vector3 position = gameObject.transform.position;
        GroundTileController leftTile = groundTileManager.getTileByPosition(position + Vector3.left);
        GroundTileController rightTile = groundTileManager.getTileByPosition(position + Vector3.right);
        GroundTileController topTile = groundTileManager.getTileByPosition(position + Vector3.up);
        GroundTileController bottomTile = groundTileManager.getTileByPosition(position + Vector3.down);

        bool leftTilled;
        bool rightTilled;
        bool topTilled;
        bool bottomTilled;

        if (leftTile != null) {
            leftTilled = leftTile.currentGroundType == GroundType.Dirt;
        }
        else {
            leftTilled = false;
        }

        if (rightTile != null) {
            rightTilled = rightTile.currentGroundType == GroundType.Dirt;
        }
        else {
            rightTilled = false;
        }

        if (topTile != null) {
            topTilled = topTile.currentGroundType == GroundType.Dirt;
        }
        else {
            topTilled = false;
        }

        if (bottomTile != null) {
            bottomTilled = bottomTile.currentGroundType == GroundType.Dirt;
        }
        else {
            bottomTilled = false;
        }

        if (bottomTilled && topTilled && leftTilled && rightTilled) {
            spriteRenderer.sprite = allClosed;
        }
        else if (!bottomTilled && !topTilled && !leftTilled && !rightTilled) {
            spriteRenderer.sprite = allOpen;
        }
        else if (bottomTilled && !topTilled && !leftTilled && !rightTilled) {
            spriteRenderer.sprite = topOpen;
        }
        else if (topTilled && !bottomTilled && !leftTilled && !rightTilled) {
            spriteRenderer.sprite = bottomOpen;
        }
        else if (leftTilled && !rightTilled && !topTilled && !bottomTilled) {
            spriteRenderer.sprite = rightOpen;
        }
        else if (rightTilled && !leftTilled && !topTilled && !bottomTilled) {
            spriteRenderer.sprite = leftOpen;
        }
        else if (rightTilled && topTilled && !bottomTilled && !leftTilled) {
            spriteRenderer.sprite = bottomLeftOpen;
        }
        else if (leftTilled && topTilled && !bottomTilled && !rightTilled) {
            spriteRenderer.sprite = bottomRightOpen;
        }
        else if (rightTilled && bottomTilled && !topTilled && !leftTilled) {
            spriteRenderer.sprite = topLeftOpen;
        }
        else if (leftTilled && bottomTilled && !topTilled && !rightTilled) {
            spriteRenderer.sprite = topRightOpen;
        }
        else {
            spriteRenderer.sprite = allClosed;
        }
    }
}
