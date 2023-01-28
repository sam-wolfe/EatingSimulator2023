using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstance : MonoBehaviour {

    [SerializeField] private Food foodSettings;
    private int chews;

    private void OnEnable() {
        transform.localScale = new Vector3(foodSettings.radius, foodSettings.radius, foodSettings.radius);
        chews = foodSettings.chewCount;
    }

    void Update()
    {
        
    }
}
