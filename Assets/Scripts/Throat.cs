using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Throat : MonoBehaviour {

    public event Action OnChoke;
    public event Action OnClearBlockage;
    
    public List<FoodInstance> foodList;

    private int chokesLeft;
    private bool isChoking;

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
        foodList.Add(food);
        OnChoke?.Invoke();
        // TODO add sound effect
        // TODO add UI panic
        // TODO Add "event" to cough until food explodes
        chokesLeft = Mathf.RoundToInt(Random.Range(8f, 12f));
        isChoking = true;
    }

    public void ProcessChoking() {
        // Returns true if was choking and is now cleared
        if (isChoking) {
            chokesLeft--;
            Debug.Log(chokesLeft);
            if (chokesLeft <= 0) {
                OnClearBlockage?.Invoke();
                isChoking = false;
                foreach (var food in foodList) {
                    if (food != null) {
                        food.BlowUp();
                    }
                }
            }
        }

    }

}
