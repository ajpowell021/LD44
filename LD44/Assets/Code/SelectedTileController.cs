using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTileController : MonoBehaviour {

    public Vector3 selectedTilePosition;
    public GameObject selectedTileObject;
    public bool showSelectedTile;

    private FarmerMovement farmerMovement;

    private void Start() {
        farmerMovement = ClassManager.instance.farmerMovement;
        selectedTileObject.SetActive(showSelectedTile);
    }

    private void Update() {
        setSelectedTile();
    }

    private void setSelectedTile() {
        Vector3 currentFacingDirection = farmerMovement.currentFacingDirection;
        Vector3 playerPostion = transform.position;

        selectedTilePosition = playerPostion + currentFacingDirection;
        selectedTilePosition.x = Mathf.Round(selectedTilePosition.x);
        selectedTilePosition.y = Mathf.Round(selectedTilePosition.y);

        if (selectedTilePosition.x > 7) {
            selectedTilePosition.x = 7;
        }
        else if (selectedTilePosition.x < -7) {
            selectedTilePosition.x = -7;
        }

        if (selectedTilePosition.y > 4) {
            selectedTilePosition.y = 4;
        }
        else if (selectedTilePosition.y < -2) {
            selectedTilePosition.y = -2;
        }
        
        
        selectedTileObject.transform.position = selectedTilePosition;
    }
}
