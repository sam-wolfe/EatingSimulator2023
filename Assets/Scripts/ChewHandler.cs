using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChewHandler : MonoBehaviour {

    [SerializeField] private Tooth _tooth;
    [SerializeField] private Tongue _tongue;
    public List<FoodInstance> foodList;
    
    [SerializeField] private ForkDetector _forkDetector;
    [SerializeField] private TongueCutter _tongueDetector;

    [SerializeField]
    private ToothBreaker _toothBreaker;

        
    [SerializeField] private AudioSource _audio;
    [SerializeField] private SoundList clips;
    void Start() {
        _tooth.OnToothTouch += HandleChew;
    }

    private void HandleChew(GameObject tooth) {
        foreach (var food in foodList) {
            if (_tooth.broken) {
                // If teeth are broken only chew food 50% of the time
                if (Random.Range(0, 100) > 50) {
                    food.Chew();
                }
            } else {
                food.Chew();
            }
        }
                        
        if (_forkDetector.forkPresent && !_tooth.broken) {
            _toothBreaker.BreakTeeth();
        }
        
        if (_tongueDetector.tonguePresent && !_tongue.isCut) {
            _tongue.CutTongue();
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
