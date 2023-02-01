using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoodForce : MonoBehaviour {
    [SerializeField] private InputManager _input;
    [SerializeField] private int _suckForce;
    
    public List<FoodInstance> foodList;

    private void Start() {
        _input.MoveFoodPerformed += HandleSuck;
    }

    private void HandleSuck() {
        foreach (var food in foodList) {
            if (food != null) {
                food.GetComponent<Rigidbody2D>().AddForce(
                    Vector2.left*_suckForce, ForceMode2D.Impulse);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null) {
            foodList.Add(food);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null) {
            foodList.Remove(food);
        }
    }
}
