using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerMovement : MonoBehaviour {

    public float moveSpeed;
    public Vector3 currentFacingDirection;
    public ParticleSystem dustMaker;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        currentFacingDirection = Vector3.down;
        dustMaker = gameObject.GetComponentInChildren<ParticleSystem>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void move(Vector3 direction) {
        if (canMoveUp(direction) && canMoveDown(direction) && canMoveLeft(direction) && canMoveRight(direction)) {
            if (direction == Vector3.right) {
                spriteRenderer.flipX = false;
                dustMaker.transform.localPosition = new Vector3(-.3f, -.4f, 0);
                dustMaker.transform.eulerAngles = new Vector3(0, 0, 72.7f);
            }
            else if (direction == Vector3.left) {
                spriteRenderer.flipX = true;
                dustMaker.transform.localPosition = new Vector3(.3f, -.4f, 0);
                dustMaker.transform.eulerAngles = new Vector3(0, 0, -72.7f);
            }
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            currentFacingDirection = direction;
            if (!dustMaker.isPlaying) {
                dustMaker.Play();
            }
        }
    }

    public void stopDustMaker() {
        dustMaker.Stop();
    }

    private bool canMoveUp(Vector3 direction) {
        if (direction == Vector3.up && transform.position.y > 5) {
            return false;
        }
        return true;
    }
    
    private bool canMoveDown(Vector3 direction) {
        if (direction == Vector3.down && transform.position.y < -4) {
            return false;
        }
        return true;
    }
    
    private bool canMoveLeft(Vector3 direction) {
        if (direction == Vector3.left && transform.position.x < -10) {
            return false;
        }
        return true;
    }
    
    private bool canMoveRight(Vector3 direction) {
        if (direction == Vector3.right && transform.position.x > 10) {
            return false;
        }
        return true;
    }
}
