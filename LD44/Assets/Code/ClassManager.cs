using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassManager : MonoBehaviour {

    public static ClassManager instance;
    
    // Classes
    public AgeManager ageManager;
    
    private void Awake() {
        setInstance();
        setClasses();
    }

    private void setInstance() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }

    private void setClasses() {
        ageManager = gameObject.GetComponent<AgeManager>();
    }
}
