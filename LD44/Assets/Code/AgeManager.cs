using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AgeManager : MonoBehaviour {

    public float ageRate;
    public float currentAge;
    public GameObject ageTextObject;
    public GameObject gameOverPanel;
    public Text scoreText;
    public float score;
    public bool dead;

    private InputManager inputManager;

    private Text ageText;

    private Animator farmerAnimator;

    private void Awake() {
        ageText = ageTextObject.GetComponent<Text>();
    }

    private void Start() {
        inputManager = ClassManager.instance.inputManager;
        farmerAnimator = ClassManager.instance.farmerAnimator;
    }

    private void Update() {
        if (!dead) {
            currentAge += Time.deltaTime * ageRate;
            score += Time.deltaTime * ageRate;
            setAgeText();
            checkDeath();
            checkAgeAnimation();
        }
    }

    private void setAgeText() {
        ageText.text = "Age: " + Mathf.FloorToInt(currentAge) + " years";
    }

    public void eatFood(int ageValue) {
        currentAge -= ageValue;
        if (currentAge < 0) {
            currentAge = 0;
        }
    }

    private void checkAgeAnimation() {
        if (currentAge <= 10) {
            if (!farmerAnimator.GetBool("isBaby")) {
                farmerAnimator.SetBool("isBaby", true);
            }
        }
        else if (currentAge > 10 && currentAge < 70) {
            if (!farmerAnimator.GetBool("isOld") || !farmerAnimator.GetBool("isBaby")) {
                farmerAnimator.SetBool("isOld", false);
                farmerAnimator.SetBool("isBaby", false);
            }
        }
        else if (currentAge >= 70) {
            if (!farmerAnimator.GetBool("isOld")) {
                farmerAnimator.SetBool("isOld", true);
            }
        }
    }

    private void checkDeath() {
        if (currentAge > 100) {
            dead = true;
            gameOverPanel.SetActive(true);
            inputManager.currentInputMode = InputMode.GameOver;
            scoreText.text = "You did manager to live a total of " + Mathf.FloorToInt(score) + " years though, so that's pretty good.";
        }
    }
}
