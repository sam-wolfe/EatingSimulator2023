using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[CreateAssetMenu(fileName = "FoodList", menuName = "ScriptableObjects/FoodList")]
public class FoodList : ScriptableObject {

    [SerializeField] private List<Food> foods;
    
    public Food getRandom() {

        if (foods.Count == 0) return null;

        var random = new Random();
        
        return foods[random.Next(foods.Count)];
        
    }

}