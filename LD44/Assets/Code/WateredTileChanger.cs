using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateredTileChanger : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    // Open meaning there is grass on that side
    public Sprite allOpen;
    public Sprite allClosed;
    public Sprite topLeftCorner;
    public Sprite topRightCorner;
    public Sprite bottomLeftCorner;
    public Sprite bottomRightCorner;
    public Sprite top;
    public Sprite bottom;
    public Sprite left;
    public Sprite right;

    private GroundTileManager groundTileManager;

    private void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start() {
        groundTileManager = ClassManager.instance.groundTileManager;
    }

    public void setWateredSprite() {
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
            spriteRenderer.sprite = top;
        }
        else if (topTilled && !bottomTilled && !leftTilled && !rightTilled) {
            spriteRenderer.sprite = bottom;
        }
        else if (leftTilled && !rightTilled && !topTilled && !bottomTilled) {
            spriteRenderer.sprite = right;
        }
        else if (rightTilled && !leftTilled && !topTilled && !bottomTilled) {
            spriteRenderer.sprite = left;
        }
        else if (rightTilled && topTilled && !bottomTilled && !leftTilled) {
            spriteRenderer.sprite = bottomLeftCorner;
        }
        else if (leftTilled && topTilled && !bottomTilled && !rightTilled) {
            spriteRenderer.sprite = bottomRightCorner;
        }
        else if (rightTilled && bottomTilled && !topTilled && !leftTilled) {
            spriteRenderer.sprite = topLeftCorner;
        }
        else if (leftTilled && bottomTilled && !topTilled && !rightTilled) {
            spriteRenderer.sprite = topRightCorner;
        }
        else {
            spriteRenderer.sprite = allClosed;
        }
    }

}
