using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundTileManager : MonoBehaviour {

    public Vector3 cratePosition;
    public Vector3 ovenPosition;
    public Vector3 vendingMachinePosition;

    public void setAllGroundSprites() {
        List<GameObject> tiles = getAllGroundTiles();
        for (int i = 0; i < tiles.Count; i++) {
            if (tiles[i].GetComponent<GroundTileController>().currentGroundType == GroundType.Dirt) {
                if (tiles[i].GetComponent<GroundTileController>().plant.watered) {
                    tiles[i].GetComponent<WateredTileChanger>().setWateredSprite();
                }
                else {
                    tiles[i].GetComponent<TilledGroundArtSetter>().detectAndSetSprite();    
                }
            }
            else {
                tiles[i].GetComponent<DirtArtSetter>().detectAndSetSprite();
            }
        }
    }

    public List<GameObject> getAllGroundTiles() {
        return GameObject.FindGameObjectsWithTag("GroundTile").ToList();
    }
    
    public GroundTileController getTileByPosition(Vector3 position) {
        List<GameObject> tiles = getAllGroundTiles();
        for (int i = 0; i < tiles.Count; i++) {
            if (tiles[i].transform.position == position) {
                return tiles[i].GetComponent<GroundTileController>();
            }
        }
       // Debug.Log("No Tile Found By That Position");
        return null;
    }
}
