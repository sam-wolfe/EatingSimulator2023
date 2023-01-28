using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChokeForce : MonoBehaviour
{
    [SerializeField] private InputManager _input;
    [SerializeField] private int chokeForce;
    public List<FoodInstance> foodList;
    private void Update() {
        foreach (var food in foodList) {
            if (food != null && _input.cough) {
                food.GetComponent<Rigidbody2D>().AddForce(
                    Vector2.up*chokeForce, ForceMode2D.Impulse);
                // TODO play sound effect
            }
        }

        if (_input.cough) {
            Debug.Log("*cough cough*");
            _input.cough = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null) {
            Debug.Log("Food Entered Choke.");
            foodList.Add(food);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null) {
            Debug.Log("Food Exited Choke.");
            foodList.Remove(food);
        }
    }
}
