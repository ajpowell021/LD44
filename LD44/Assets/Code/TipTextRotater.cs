using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipTextRotater : MonoBehaviour {

    private Text thisText;
    
    
    
    private void Start() {
        thisText = gameObject.GetComponent<Text>();
        InvokeRepeating("SetText", 0.1f, 5f);
    }

    private void SetText() {
        int roll = Random.Range(0, 9);

        switch (roll) {
            case 0:
                thisText.text = "Put veggies in bin to cook.";
                break;
            case 1:
                thisText.text = "The oven is for cooking better food.";
                break;
            case 2:
                thisText.text = "Careful, buying seeds costs years of your life";
                break;
            case 3:
                thisText.text = "Most people die around 100 years old.";
                break;
            case 4:
                thisText.text = "You can only hold one thing at a time.";
                break;
            case 5:
                thisText.text = "Press Z to drop things";
                break;
            case 6:
                thisText.text = "There's no winning, just not dying.";
                break;
            case 7:
                thisText.text = "Tilled soil always returns back to grass eventually";
                break;
            case 8:
                thisText.text = "You can eat food raw, but cooking is always better";
                break;
        }
        
    }

    
 
}
