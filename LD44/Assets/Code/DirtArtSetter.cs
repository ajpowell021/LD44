using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtArtSetter : MonoBehaviour {

    // Sprites
    // Sides refer to the sides that have a tilled ground.
    public Sprite allSides;
    public Sprite normalGrass;

    public Sprite topLeft;
    public Sprite topRight;
    public Sprite bottomLeft;
    public Sprite bottomRight;

    public Sprite topLeftRight;
    public Sprite leftTopBottom;
    public Sprite rightTopBottom;
    public Sprite bottomLeftRight;

    private SpriteRenderer spriteRenderer;
    private GroundTileManager groundTileManager;
    
    private bool leftTilled;
    private bool rightTilled;
    private bool topTilled;
    private bool bottomTilled;
    private bool topLeftTilled;
    private bool topRightTilled;
    private bool bottomLeftTilled;
    private bool bottomRightTilled;

    private void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        normalGrass = spriteRenderer.sprite;
    }

    private void Start() {
        groundTileManager = ClassManager.instance.groundTileManager;
    }

    public void detectAndSetSprite() {
        setTilledBooleans();
        
        // Assigning the renderer
        if (surroundedOnAllSides()) {
            spriteRenderer.sprite = allSides;
        }
        else if (topSurrounded()) {
            spriteRenderer.sprite = topLeftRight;
        }
        else if (bottomSurrounded()) {
            spriteRenderer.sprite = bottomLeftRight;
        }
        else if (leftSurrounded()) {
            spriteRenderer.sprite = leftTopBottom;
        }
        else if (rightSurrounded()) {
            spriteRenderer.sprite = rightTopBottom;
        }
        else if (topRightCorner()) {
            spriteRenderer.sprite = topRight;
        }
        else if (topLeftCorner()) {
            spriteRenderer.sprite = topLeft;
        }
        else if (bottomRightCorner()) {
            spriteRenderer.sprite = bottomRight;
        }
        else if (bottomLeftCorner()) {
            spriteRenderer.sprite = bottomLeft;
        }
        else {
            spriteRenderer.sprite = normalGrass;
        }
    }
    
    // Private Functions

    private void setTilledBooleans() {
        Vector3 position = gameObject.transform.position;
        GroundTileController leftTile = groundTileManager.getTileByPosition(position + Vector3.left);
        GroundTileController rightTile = groundTileManager.getTileByPosition(position + Vector3.right);
        GroundTileController topTile = groundTileManager.getTileByPosition(position + Vector3.up);
        GroundTileController bottomTile = groundTileManager.getTileByPosition(position + Vector3.down);
        GroundTileController diagTopLeft = groundTileManager.getTileByPosition(position + Vector3.up + Vector3.left);
        GroundTileController diagTopRight = groundTileManager.getTileByPosition(position + Vector3.up + Vector3.right);
        GroundTileController diagBottomRight = groundTileManager.getTileByPosition(position + Vector3.down + Vector3.right);
        GroundTileController diagBottomLeft = groundTileManager.getTileByPosition(position + Vector3.down + Vector3.left);

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

        if (diagTopLeft != null) {
            topLeftTilled = diagTopLeft.currentGroundType == GroundType.Dirt;
        }
        else {
            topLeftTilled = false;
        }
        
        if (diagTopRight != null) {
            topRightTilled = diagTopRight.currentGroundType == GroundType.Dirt;
        }
        else {
            topRightTilled = false;
        }
        
        if (diagBottomLeft != null) {
            bottomLeftTilled = diagBottomLeft.currentGroundType == GroundType.Dirt;
        }
        else {
            bottomLeftTilled = false;
        }
        
        if (diagBottomRight != null) {
            bottomRightTilled = diagBottomRight.currentGroundType == GroundType.Dirt;
        }
        else {
            bottomRightTilled = false;
        }
    }

    private bool surroundedOnAllSides() {
        return fullTop() && fullLeft() && fullRight() && fullBottom();
    }

    private bool fullTop() {
        return topLeftTilled && topTilled && topRightTilled;
    }

    private bool fullLeft() {
        return topLeftTilled && leftTilled && bottomLeftTilled;
    }

    private bool fullRight() {
        return topRightTilled && rightTilled
                              && bottomRightTilled;
    }

    private bool fullBottom() {
        return bottomLeftTilled && bottomTilled && bottomRightTilled;
    }

    private bool topRightCorner() {
        return topRightTilled && topTilled && rightTilled;
    }

    private bool bottomRightCorner() {
        return rightTilled && bottomTilled && bottomRightTilled;
    }

    private bool topLeftCorner() {
        return topTilled && leftTilled && topLeftTilled;
    }

    private bool bottomLeftCorner() {
        return bottomTilled && leftTilled && bottomLeftTilled;
    }

    private bool topSurrounded() {
        return topTilled && topLeftTilled && topRightTilled && leftTilled && rightTilled;
    }

    private bool bottomSurrounded() {
        return leftTilled && bottomLeftTilled && bottomTilled && bottomRightTilled && rightTilled;
    }

    private bool leftSurrounded() {
        return topTilled && topLeftTilled && leftTilled && bottomLeftTilled && bottomTilled;
    }

    private bool rightSurrounded() {
        return topTilled && topRightTilled && rightTilled && bottomRightTilled && bottomTilled;
    }
}
