using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AgeManager : MonoBehaviour {

    public float ageRate;
    public float currentAge;
    public GameObject ageTextObject;

    private TextMeshProUGUI ageText;

    private void Awake() {
        ageText = ageTextObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        currentAge += Time.deltaTime * ageRate;
        setAgeText();
    }

    private void setAgeText() {
        ageText.text = "Age: " + Mathf.FloorToInt(currentAge) + " years";
    }
}
