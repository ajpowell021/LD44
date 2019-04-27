using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerMovement : MonoBehaviour {

    public float moveSpeed;
    public Vector3 currentFacingDirection;

    private void Awake() {
        currentFacingDirection = Vector3.down;
    }

    public void move(Vector3 direction) {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        currentFacingDirection = direction;
    }
}
