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
    public TextMeshProUGUI scoreText;
    public float score;
    public bool dead;

    private InputManager inputManager;

    private TextMeshProUGUI ageText;

    private void Awake() {
        ageText = ageTextObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        inputManager = ClassManager.instance.inputManager;
    }

    private void Update() {
        if (!dead) {
            currentAge += Time.deltaTime * ageRate;
            score += Time.deltaTime * ageRate;
            setAgeText();
            checkDeath();    
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

    private void checkDeath() {
        if (currentAge > 100) {
            dead = true;
            gameOverPanel.SetActive(true);
            inputManager.currentInputMode = InputMode.GameOver;
            scoreText.text = "You did manager to live a total of " + Mathf.FloorToInt(score) + " years though, so that's pretty good.";
        }
    }
}
