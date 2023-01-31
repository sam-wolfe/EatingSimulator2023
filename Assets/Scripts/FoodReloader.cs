using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReloader : MonoBehaviour {
    
    
    private Fork _fork;
    
    void Start() {
        _fork = FindObjectOfType<Fork>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Fork") {
            LoadFood();
        } 
    }

    private void LoadFood() {
        // TODO
        Debug.Log("Add food to fork.");
        _fork.LoadFork();
    }
}
