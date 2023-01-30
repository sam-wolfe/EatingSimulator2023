using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerManager : MonoBehaviour {

    [SerializeField] private int foodLevel = 100;

    public event Action<int> OnFoodGain;
    public event Action<int> OnStarve;
    
    void Start()
    {
        StartCoroutine(Starve());

    }

    public void addFood(int food) {
        foodLevel += food;
        if (foodLevel > 100) foodLevel = 100;
        OnFoodGain?.Invoke(foodLevel);
    }
    

    private IEnumerator Starve() {
        while (true) {
            yield return new WaitForSeconds(1f);
            foodLevel--;
            if (foodLevel <= 0) {
                // TODO trigger game over
            }
            OnStarve?.Invoke(foodLevel);
        }
    }

}
