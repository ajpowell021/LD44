using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundTileManager : MonoBehaviour {

    public List<GameObject> getAllGroundTiles() {
        return GameObject.FindGameObjectsWithTag("GroundTile").ToList();
    }
    
    public GroundTileController getTileByPosition(Vector3 position) {
        List<GameObject> tiles = getAllGroundTiles();
        Debug.Log("position: " + position);
        Debug.Log("Count: " + tiles.Count);
        for (int i = 0; i < tiles.Count; i++) {
            if (tiles[i].transform.position == position) {
                return tiles[i].GetComponent<GroundTileController>();
            }
        }
        Debug.Log("No Tile Found By That Position");
        return null;
    }
}
