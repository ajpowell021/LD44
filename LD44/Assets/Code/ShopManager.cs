using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public GameObject shopPanel;

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

//    public List<ItemType> itemsThatCanBeSold = new List<ItemType> {
//        ItemType.CornSeed,
//        ItemType.CarrotSeed,
//        ItemType.PotatoeSeed,
//        ItemType.Veg4Seed,
//        ItemType.Veg5Seed
//    };

    public List<ItemType> itemsThatCanBeSold = new List<ItemType>();

    private void Start() {
        spriteManager = ClassManager.instance.spriteManager;
        restock();
    }

    private void Update() {
        updateRestockTime();
    }

    public void toggleShopPanel() {
        shopPanel.SetActive(!shopPanel.activeInHierarchy);
    }

    private void updateRestockTime() {
        currentTimeToRestock += Time.deltaTime;
        restockTime.text = "Restock in: " + (30 - Mathf.FloorToInt(currentTimeToRestock)) + "s";
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
            case ItemType.CornSeed:
                return "Seeds to plant corn. Costs " + seedPrice + " years to buy";
            case ItemType.CarrotSeed:
                return "Seeds to plant carrot. Costs " + seedPrice + " years to buy";
            case ItemType.PotatoeSeed:
                return "Seeds to plant potatoes. Costs " + seedPrice + " years to buy";
            case ItemType.Veg4Seed:
                return "Seeds to plant Veg4. Costs " + seedPrice + " years to buy";
            case ItemType.Veg5Seed:
                return "Seeds to plant Veg5. Costs " + seedPrice + " years to buy";
        }
    
        Debug.Log("No description for item");
        return "ERROR";
    }
}
