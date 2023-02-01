using UnityEngine;

public class FoodReloader : MonoBehaviour {
    
    [SerializeField] private FoodList _foodList;
    
    private Fork _fork;
    
    
    void Start() {
        _fork = FindObjectOfType<Fork>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Fork") {
            LoadFood();
        } 
    }

    private void LoadFood() {
        var nextFood = _foodList.getRandom();
        _fork.LoadFork(nextFood);
    }
}
