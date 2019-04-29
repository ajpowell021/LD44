using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour {

    private AudioSource audioSource;
    public List<AudioClip> clips;

    private void Awake() {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start() {
    }

    public void playSound() {
        audioSource.Play();
    }

    public void stopAllSounds() {
        audioSource.Stop();
    }
    
    public void playHitGround() {
        audioSource.clip = clips[0];
        playSound();
    }

    public void playPurchaseSound() {
        audioSource.clip = clips[1];
        playSound();
    }

}
