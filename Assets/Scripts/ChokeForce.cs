using System.Collections.Generic;
using UnityEngine;

public class ChokeForce : MonoBehaviour
{
    [SerializeField] private InputManager _input;
    private ForceProvider _forceProvider;
    
    // Bad, hacking because sleep deprived and running out of time for gamejam
    [SerializeField] private Throat _throat;
    
    public List<FoodInstance> foodList;

    
    // Audio

    [SerializeField] private AudioSource _audio;
    [SerializeField] private SoundList clips;
    
    [SerializeField] private UIManager _uiManager;
    
    //------------
    
    private void Start() {
        _input.CoughPerformed += HandleCough;
        _forceProvider = FindObjectOfType<ForceProvider>();
    }
    
    private void HandleCough() {
        foreach (var food in foodList) {
            if (food != null) {
                food.GetComponent<Rigidbody2D>().AddForce(
                    Vector2.up*_forceProvider.get(), ForceMode2D.Impulse);
            }
        }

        Debug.Log("*cough cough*");
        _throat.ProcessChoking();
        _audio.PlayOneShot(clips.getRandom());
        
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
            foodList.Remove(food);

            // TODO handle score increase elsewhere
            // _uiManager.increaseScore();
        }
    }
}
