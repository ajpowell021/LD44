using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour {

    public int garlicCount;
    public int carrotCount;
    public int potatoesCount;
    public int pepperCount;
    public int chickpeaCount;

    public Text garlicText;
    public Text pepperText;
    public Text carrotText;
    public Text chickpeaText;
    public Text potatoText;

    public float cookTime;

    public bool isCooking;
    
    public int rawGarlicAge;
    public int rawCarrotAge;
    public int rawPotatoAge;
    public int rawPepperAge;
    public int rawChickpeaAge;
    public int recipeOneAge;
    public int recipeTwoAge;
    public int recipeThreeAge;
    public int recipeFourAge;
    public int recipeFiveAge;

    public GameObject uiSelector;

    public GameObject recipeOneObject;
    public GameObject recipeTwoObject;
    public GameObject recipeThreeObject;
    public GameObject recipeFourObject;
    public GameObject recipeFiveObject;
    public GameObject exitObject;
    
    public GameObject recipePanel;

    private InputManager inputManager;
    private PrefabManager prefabManager;
    private GroundTileManager groundTileManager;
    public int selectedRecipeIndex;

    private void Start() {
        inputManager = ClassManager.instance.inputManager;
        prefabManager = ClassManager.instance.prefabManager;
        groundTileManager = ClassManager.instance.groundTileManager;
        updateUiFoodCounts();
    }

    public int getAgeFromItemType(ItemType itemType) {
        switch (itemType) {
            case ItemType.Garlic:
                return rawGarlicAge;
            case ItemType.Carrot:
                return rawCarrotAge;
            case ItemType.Potatoe:
                return rawPotatoAge;
            case ItemType.Pepper:
                return rawPepperAge;
            case ItemType.Chickpea:
                return rawChickpeaAge;
            case ItemType.RecipeOne:
                return recipeOneAge;
            case ItemType.RecipeTwo:
                return recipeTwoAge;
            case ItemType.RecipeThree:
                return recipeThreeAge;
            case ItemType.RecipeFour:
                return recipeFourAge;
            case ItemType.RecipeFive:
                return recipeFiveAge;
            default:
                Debug.Log("Error: no age data for that item type");
                return 0;
        }
    }

    public void addItemToStorage(ItemType itemType) {
        switch (itemType) {
            case ItemType.Garlic:
                garlicCount++;
                break;
            case ItemType.Carrot:
                carrotCount++;
                break;
            case ItemType.Potatoe:
                potatoesCount++;
                break;
            case ItemType.Pepper:
                pepperCount++;
                break;
            case ItemType.Chickpea:
                chickpeaCount++;
                break;
            default:
                Debug.Log("No food count matching item type");
                break;
        }
        updateUiFoodCounts();
    }

    public void toggleRecipePanel() {
        recipePanel.SetActive(!recipePanel.activeInHierarchy);
        if (recipePanel.activeInHierarchy) {
            StartCoroutine(inputManager.changeInputMode(InputMode.RecipeMenu));
            setSelectedText();
        }
        else {
            StartCoroutine(inputManager.changeInputMode(InputMode.Play));
            selectedRecipeIndex = 0;
        }
    }

    public void adjustSelectedRecipeIndex(int adjust) {
        selectedRecipeIndex += adjust;
        if (selectedRecipeIndex == 6) {
            selectedRecipeIndex = 0;
        }
        else if (selectedRecipeIndex == -1) {
            selectedRecipeIndex = 5;
        }
        
        setSelectedText();
    }

    public void executeSelectedAction() {
        if (selectedRecipeIndex == 5) {
            toggleRecipePanel();
        }
        else {
            if (canCookByRecipeNumber(selectedRecipeIndex + 1)) {
                startCookingByRecipeNumber(selectedRecipeIndex + 1);
                toggleRecipePanel();
            }
        }
    }

    private void setSelectedText() {
        switch (selectedRecipeIndex) {
            case 0:
                uiSelector.transform.localPosition = new Vector3(0, 82, 0);
                break;
            case 1:
                uiSelector.transform.localPosition = new Vector3(0, 42, 0);
                break;
            case 2:
                uiSelector.transform.localPosition = new Vector3(0, 7, 0);
                break;
            case 3:
                uiSelector.transform.localPosition = new Vector3(0, -30, 0);
                break;
            case 4:
                uiSelector.transform.localPosition = new Vector3(0, -62, 0);
                break;
            case 5:
                uiSelector.transform.localPosition = new Vector3(0, -100, 0);
                break;
            defualt:
                Debug.Log("Error: Selector is out of range");
                break;
        }
    }

    private bool canCookByRecipeNumber(int recipeNumber) {
        switch (recipeNumber) {
            case 1:
                if (potatoesCount > 0 && garlicCount > 0) {
                    potatoesCount--;
                    garlicCount--;
                    updateUiFoodCounts();
                    return true;
                }
                return false;
            case 2:
                if (carrotCount > 0 && chickpeaCount > 0) {
                    carrotCount--;
                    chickpeaCount--;
                    updateUiFoodCounts();
                    return true;
                }
                return false;
            case 3:
                if (pepperCount > 0 && potatoesCount > 0) {
                    pepperCount--;
                    potatoesCount--;
                    updateUiFoodCounts();
                    return true;
                }
                return false;
            case 4:
                if (pepperCount > 0 && chickpeaCount > 0 && garlicCount > 0) {
                    pepperCount--;
                    chickpeaCount--;
                    garlicCount--;
                    updateUiFoodCounts();
                    return true;
                }
                return false;
            case 5: 
                if (potatoesCount > 0 && carrotCount > 0 && chickpeaCount > 0 && garlicCount > 0 && pepperCount > 0) {
                    potatoesCount--;
                    carrotCount--;
                    chickpeaCount--;
                    garlicCount--;
                    pepperCount--;
                    updateUiFoodCounts();
                    return true;
                }
                return false;
            default:
                Debug.Log("item count out of range!");
                return false;
        }
    }

    private ItemType getItemTypeFromRecipeNumber(int recipeNumber) {
        switch (recipeNumber) {
            case 1:
                return ItemType.RecipeOne;
            case 2:
                return ItemType.RecipeTwo;
            case 3:
                return ItemType.RecipeThree;
            case 4:
                return ItemType.RecipeFour;
            case 5:
                return ItemType.RecipeFive;
            default:
                Debug.Log("Error: Un handled recipe number!");
                return ItemType.RecipeOne;
        }
    }

    private void startCookingByRecipeNumber(int recipeNumber) {
        isCooking = true;
        StartCoroutine(startCooking(getItemTypeFromRecipeNumber(recipeNumber)));
    }

    private IEnumerator startCooking(ItemType itemType) {
        yield return new WaitForSeconds(cookTime);
        Instantiate(prefabManager.getObjectByItemType(itemType), groundTileManager.ovenPosition + Vector3.down, Quaternion.identity);
        isCooking = false;
    }

    public void updateUiFoodCounts() {
        carrotText.text = "Carrots: " + carrotCount;
        garlicText.text = "Garlic: " + garlicCount;
        chickpeaText.text = "Chickpea: " + chickpeaCount;
        pepperText.text = "Peppers: " + pepperCount;
        potatoText.text = "Potatoes: " + potatoesCount;
    }

    public void gameOverHide() {
        recipePanel.SetActive(false);
    }
}
