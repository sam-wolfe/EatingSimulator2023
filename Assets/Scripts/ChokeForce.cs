using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ChokeForce : MonoBehaviour
{
    [SerializeField] private InputManager _input;
    [SerializeField] private int chokeForce;
    
    // Bad, hacking because sleep deprived and running out of time for gamejam
    [SerializeField] private Throat _throat;
    
    public List<FoodInstance> foodList;

    [SerializeField] private HungerManager _hungerManager;
    
    // Audio

    [SerializeField] private AudioSource _audio;
    [SerializeField] private SoundList clips;
    
    [SerializeField] private UIManager _uiManager;
    
    //------------
    
    
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
            _throat.ProcessChoking();
            _audio.PlayOneShot(clips.getRandom());
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
            _hungerManager.addFood(food.foodSettings.chewCount * 2);
            foodList.Remove(food);
            _uiManager.increaseScore();
        }
    }
}
