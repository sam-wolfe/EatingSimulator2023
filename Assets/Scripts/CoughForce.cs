using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughForce : MonoBehaviour
{
    [SerializeField] private InputManager _input;
    public List<FoodInstance> foodList;
    [SerializeField] private int chokeForce;

    private void Start() {
        _input.CoughPerformed += HandleCough;
    }

    private void HandleCough() {
        foreach (var food in foodList) {
            if (food != null) {
                food.GetComponent<Rigidbody2D>().AddForce(
                    Vector2.right*chokeForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null) {
            Debug.Log("Food Entered Cough.");
            foodList.Add(food);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null) {
            Debug.Log("Food Exited Cough.");
            foodList.Remove(food);
        }
    }
}
