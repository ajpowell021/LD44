using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour {

    public int cornCount;
    public int carrotCount;
    public int potatoes;
    public int veg4;
    public int veg5;
    
    public int rawCornAge;
    public int rawCarrotAge;
    
    public GameObject recipePanel;

    private InputManager inputManager;

    public Color32 selectedColor;
    public Color32 unselectedColor;
    public int selectedRecipeIndex;
    public List<GameObject> recipeTextObjects = new List<GameObject>();

    private void Start() {
        inputManager = ClassManager.instance.inputManager;
    }

    public int getAgeFromItemType(ItemType itemType) {
        switch (itemType) {
            case ItemType.Corn:
                return rawCornAge;
            case ItemType.Carrot:
                return rawCarrotAge;
            default:
                Debug.Log("Error: no age data for that item type");
                return 0;
        }
    }

    public void addItemToStorage(ItemType itemType) {
        switch (itemType) {
            case ItemType.Corn:
                cornCount++;
                break;
            case ItemType.Carrot:
                carrotCount++;
                break;
            default:
                Debug.Log("No food count matching item type");
                break;
        }
    }

    public void toggleRecipePanel() {
        recipePanel.SetActive(!recipePanel.activeInHierarchy);
        if (recipePanel.activeInHierarchy) {
            inputManager.currentInputMode = InputMode.RecipeMenu;
            setSelectedText();
        }
        else {
            inputManager.currentInputMode = InputMode.Play;
        }
    }

    public void adjustSelectedRecipeIndex(int adjust) {
        selectedRecipeIndex += adjust;
        if (selectedRecipeIndex == 7) {
            selectedRecipeIndex = 0;
        }
        else if (selectedRecipeIndex == -1) {
            selectedRecipeIndex = 6;
        }
        
        setSelectedText();
    }

    private void setSelectedText() {
        for (int i = 0; i < recipeTextObjects.Count; i++) {
            if (i == selectedRecipeIndex) {
                recipeTextObjects[i].GetComponent<TextMeshProUGUI>().color = selectedColor;
            }
            else {
                recipeTextObjects[i].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            }
        }
        
    }
}
