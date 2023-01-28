using System;
using DefaultNamespace;
using UnityEngine;

public class GagReflex : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null && !food.IsChewed()) {
            Debug.Log("Oh god I'm going to choke.");
            Gag();
        }
    }

    private void Gag() {
        
    }

}
