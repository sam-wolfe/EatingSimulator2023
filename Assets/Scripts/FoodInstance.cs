using System;
using DefaultNamespace;
using UnityEngine;

public class FoodInstance : MonoBehaviour {

    [SerializeField] private Food foodSettings;
    private int chews;

    private void OnEnable() {
        transform.localScale = new Vector3(foodSettings.radius, foodSettings.radius, foodSettings.radius);
        chews = foodSettings.chewCount;
    }

    public void Chew() {
        if (chews > 0) {
            chews--;
        }
    }

    public bool IsChewed() {
        return chews == 0;
    }
    
    // private void OnCollisionEnter2D(Collision2D col) {
    //     IFoodProcessor foodProcessor = col.gameObject.GetComponent<IFoodProcessor>();
    //     if (foodProcessor != null) {
    //         foodProcessor.IncomingFood(this);
    //         Debug.Log("apple");
    //     }
    // }

}
