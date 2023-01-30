using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughForce : MonoBehaviour
{
    [SerializeField] private InputManager _input;
    public List<FoodInstance> foodList;

    private ForceProvider _forceProvider;
    
    private void Start() {
        _input.CoughPerformed += HandleCough;
        _forceProvider = FindObjectOfType<ForceProvider>();
    }

    private void HandleCough() {
        foreach (var food in foodList) {
            if (food != null) {
                food.GetComponent<Rigidbody2D>().AddForce(
                    Vector2.right*_forceProvider.get(), ForceMode2D.Impulse);
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
