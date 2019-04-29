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
    public int veg5Count;

    public float cookTime;

    public bool isCooking;
    
    public int rawGarlicAge;
    public int rawCarrotAge;
    public int rawPotatoAge;
    public int rawPepperAge;
    public int rawVeg5Age;
    public int recipeOneAge;
    public int recipeTwoAge;
    public int recipeThreeAge;
    public int recipeFourAge;
    public int recipeFiveAge;
    public int recipeSixAge;
    
    public GameObject recipePanel;

    private InputManager inputManager;
    private PrefabManager prefabManager;
    private GroundTileManager groundTileManager;

    public Color32 selectedColor;
    public Color32 unselectedColor;
    public int selectedRecipeIndex;
    public List<GameObject> recipeTextObjects = new List<GameObject>();

    private void Start() {
        inputManager = ClassManager.instance.inputManager;
        prefabManager = ClassManager.instance.prefabManager;
        groundTileManager = ClassManager.instance.groundTileManager;
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
            case ItemType.Veg5:
                return rawVeg5Age;
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
            case ItemType.RecipeSix:
                return recipeSixAge;
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
            case ItemType.Veg5:
                veg5Count++;
                break;
            default:
                Debug.Log("No food count matching item type");
                break;
        }
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
        if (selectedRecipeIndex == 7) {
            selectedRecipeIndex = 0;
        }
        else if (selectedRecipeIndex == -1) {
            selectedRecipeIndex = 6;
        }
        
        setSelectedText();
    }

    public void executeSelectedAction() {
        if (selectedRecipeIndex == 6) {
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
        for (int i = 0; i < recipeTextObjects.Count; i++) {
            if (i == selectedRecipeIndex) {
                recipeTextObjects[i].GetComponent<TextMeshProUGUI>().color = selectedColor;
            }
            else {
                recipeTextObjects[i].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            }
        }
    }

    private bool canCookByRecipeNumber(int recipeNumber) {
        switch (recipeNumber) {
            case 1:
                if (carrotCount > 0 && garlicCount > 0) {
                    carrotCount--;
                    garlicCount--;
                    return true;
                }
                return false;
            case 2:
                if (carrotCount > 1 && pepperCount > 1) {
                    carrotCount--;
                    pepperCount--;
                    return true;
                }
                return false;
            case 3:
                if (pepperCount > 1 && veg5Count > 1) {
                    pepperCount--;
                    veg5Count--;
                    return true;
                }
                return false;
            case 4:
                if (potatoesCount > 1 && veg5Count > 1) {
                    potatoesCount--;
                    veg5Count--;
                    return true;
                }
                return false;
            case 5: 
                if (potatoesCount > 1 && carrotCount > 1 && veg5Count > 1) {
                    potatoesCount--;
                    carrotCount--;
                    veg5Count--;
                    return true;
                }
                return false;
            case 6:
                if (potatoesCount > 0 && carrotCount > 0 && garlicCount > 0 && pepperCount > 0 && veg5Count > 0) {
                    potatoesCount--;
                    carrotCount--;
                    garlicCount--;
                    pepperCount--;
                    veg5Count--;
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
            case 6:
                return ItemType.RecipeSix;
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
}
