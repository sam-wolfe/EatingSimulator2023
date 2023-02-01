using UnityEngine;

public class GagReflex : MonoBehaviour {
    
    [SerializeField] private AudioSource _audio;
    [SerializeField] private SoundList clips;

    private void OnTriggerEnter2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null && !food.IsChewed()) {
            Debug.Log("Oh god I'm going to choke.");
            Gag();
        }
    }

    private void Gag() {
        _audio.PlayOneShot(clips.getRandom());
    }

}
