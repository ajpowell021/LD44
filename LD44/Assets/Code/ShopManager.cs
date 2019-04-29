using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public GameObject shopPanel;
    public GameObject selector;

    public int currentSelectedItem;

    public float currentTimeToRestock;
    public float maxRestockTime;

    public ItemType itemOne;
    public ItemType itemTwo;
    public ItemType itemThree;

    public int seedPrice;

    public TextMeshProUGUI textOne;
    public TextMeshProUGUI textTwo;
    public TextMeshProUGUI textThree;
    public TextMeshProUGUI restockTime;

    public Image imageOne;
    public Image imageTwo;
    public Image imageThree;

    private SpriteManager spriteManager;
    private InputManager inputManager;
    private AgeManager ageManager;
    private PrefabManager prefabManager;

    public List<ItemType> itemsThatCanBeSold = new List<ItemType>();

    private void Start() {
        spriteManager = ClassManager.instance.spriteManager;
        inputManager = ClassManager.instance.inputManager;
        ageManager = ClassManager.instance.ageManager;
        prefabManager = ClassManager.instance.prefabManager;
        restock();
    }

    private void Update() {
        updateRestockTime();
    }

    public void toggleShopPanel() {
        shopPanel.SetActive(!shopPanel.activeInHierarchy);
        if (!shopPanel.activeInHierarchy) {
            currentSelectedItem = 0;
            inputManager.currentInputMode = InputMode.Play;
        }
        else {
            inputManager.currentInputMode = InputMode.ShopMenu;
            moveSelector(0);
        }
    }

    private void updateRestockTime() {
        currentTimeToRestock += Time.deltaTime;
        restockTime.text = "Restock in: " + (30 - Mathf.FloorToInt(currentTimeToRestock)) + " seconds";
        if (currentTimeToRestock >= maxRestockTime) {
            restock();
        }
    }

    private void restock() {
        int roll = Random.Range(0, itemsThatCanBeSold.Count);
        int rollTwo = Random.Range(0, itemsThatCanBeSold.Count);
        while (rollTwo == roll) {
            rollTwo = Random.Range(0, itemsThatCanBeSold.Count);
        }
        int rollThree = Random.Range(0, itemsThatCanBeSold.Count);
        while (rollThree == roll || rollThree == rollTwo) {
            rollThree = Random.Range(0, itemsThatCanBeSold.Count);
        }

        itemOne = itemsThatCanBeSold[roll];
        itemTwo = itemsThatCanBeSold[rollTwo];
        itemThree = itemsThatCanBeSold[rollThree];

        setShopUi();

        currentTimeToRestock = 0;
    }

    private void setShopUi() {
        imageOne.sprite = spriteManager.getSpriteByItemType(itemOne);
        imageTwo.sprite = spriteManager.getSpriteByItemType(itemTwo);
        imageThree.sprite = spriteManager.getSpriteByItemType(itemThree);

        textOne.text = getDesciptionByItemType(itemOne);
        textTwo.text = getDesciptionByItemType(itemTwo);
        textThree.text = getDesciptionByItemType(itemThree);
    }

    private string getDesciptionByItemType(ItemType item) {
        switch (item) {
            case ItemType.GarlicSeed:
                return "Seeds to plant garlic. Costs " + seedPrice + " years to buy";
            case ItemType.CarrotSeed:
                return "Seeds to plant carrot. Costs " + seedPrice + " years to buy";
            case ItemType.PotatoeSeed:
                return "Seeds to plant potatoes. Costs " + seedPrice + " years to buy";
            case ItemType.PepperSeed:
                return "Seeds to plant peppers. Costs " + seedPrice + " years to buy";
            case ItemType.ChickpeaSeed:
                return "Seeds to plant chickpea. Costs " + seedPrice + " years to buy";
        }
    
        Debug.Log("No description for item");
        return "ERROR";
    }

    public void moveSelector(int adjust) {
        currentSelectedItem += adjust;

        if (currentSelectedItem == -1) {
            currentSelectedItem = 3;
        }
        else if (currentSelectedItem == 4) {
            currentSelectedItem = 0;
        }

        switch (currentSelectedItem) {
            case 0:
                selector.transform.localPosition = new Vector3(-9.5f, 225, 0);
                break;
            case 1:
                selector.transform.localPosition = new Vector3(-9.5f, 81, 0);
                break;
            case 2:
                selector.transform.localPosition = new Vector3(-9.5f, -64, 0);
                break;
            case 3:
                selector.transform.localPosition = new Vector3(-9.5f, -216, 0);
                break;
        }
    }

    public void makeSelection() {
        switch (currentSelectedItem) {
            case 0:
                purchaseItem(itemOne);
                break;
            case 1:
                purchaseItem(itemTwo);
                break;
            case 2:
                purchaseItem(itemThree);
                break;
            case 3:
                toggleShopPanel();
                break;
        }
    }

    private void purchaseItem(ItemType itemType) {
        switch (itemType) {
            case ItemType.GarlicSeed:
            case ItemType.CarrotSeed:
            case ItemType.PotatoeSeed:
            case ItemType.PepperSeed:
            case ItemType.ChickpeaSeed:
                ageManager.eatFood(-seedPrice);
                Instantiate(prefabManager.getObjectByItemType(itemType), new Vector3(9, 5, 0), Quaternion.identity);
                break;
        }
    }
}
