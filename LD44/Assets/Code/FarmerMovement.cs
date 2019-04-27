using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerMovement : MonoBehaviour {

    public float moveSpeed;

    public void move(Vector3 direction) {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
