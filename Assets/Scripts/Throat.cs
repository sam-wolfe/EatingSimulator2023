using System;
using DefaultNamespace;
using UnityEngine;

public class Throat : MonoBehaviour {

    public event Action OnChoke;

    private void OnTriggerEnter2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null && !food.IsChewed()) {
            Debug.Log("GACK HEKdsf B SKAAAAAAA.");
            Choke(food);
        }
    }
    
    // private void OnCollisionEnter2D(Collision2D col) {
    //     if (col.gameObject.CompareTag("Throat")) {
    //         Debug.Log("Swallowing THROAT COLLISION");
    //     }
    // }

    public void Choke(FoodInstance food) {
        var f_rb = food.GetComponent<Rigidbody2D>();
        f_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        OnChoke?.Invoke();
        // TODO add sound effect
        // TODO add UI panic
        // TODO Add "event" to cough until food explodes
    }

}
