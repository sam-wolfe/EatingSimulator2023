using System;
using UnityEngine;

public class ScoreCaluclator : MonoBehaviour {

    private int score;
    public event Action<int> OnScoreIncrease;
    
    [SerializeField] private HungerManager _hungerManager;

    private void OnTriggerEnter2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null && food.IsChewed()) {
            
            Debug.Log("Swallowed food.");
            score++;
            OnScoreIncrease?.Invoke(score);
            
            _hungerManager.addFood(food.foodSettings.chewCount * 2);

        }
    }
}
