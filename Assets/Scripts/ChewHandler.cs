using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewHandler : MonoBehaviour {

    [SerializeField] private Tooth _tooth;
    public List<FoodInstance> foodList;

        
    [SerializeField] private AudioSource _audio;
    [SerializeField] private SoundList clips;
    public event Action OnChew;
    void Start() {
        _tooth.OnToothTouch += HandleChew;
    }

    private void HandleChew(GameObject tooth) {
        // OnChew?.Invoke();
        foreach (var food in foodList) {
            food.Chew();
        }
        _audio.PlayOneShot(clips.getRandom());
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null) {
            Debug.Log("Food Entered mouth.");
            foodList.Add(food);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null) {
            Debug.Log("Food Exited mouth.");
            foodList.Remove(food);
        }
    }

}
