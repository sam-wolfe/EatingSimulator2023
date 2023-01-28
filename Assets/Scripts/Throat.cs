using System;
using DefaultNamespace;
using UnityEngine;

public class Throat : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null && !food.IsChewed()) {
            Debug.Log("GACK HEKdsf B SKAAAAAAA.");
            Choke();
        }
    }
    
    // private void OnCollisionEnter2D(Collision2D col) {
    //     if (col.gameObject.CompareTag("Throat")) {
    //         Debug.Log("Swallowing THROAT COLLISION");
    //     }
    // }

    public void Choke() {
        // TODO implement
    }

}
