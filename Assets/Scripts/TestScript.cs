using UnityEngine;

public class TestScript : MonoBehaviour {

    [SerializeField] private Food foodItem;
    [SerializeField] private InputManager _input;
    [SerializeField] private FoodList _foodList;
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            Instantiate(foodItem.prefab, transform.position, Quaternion.identity);
        }

        if (_input.food) {
            var nextFood = _foodList.getRandom();
            Instantiate(nextFood.prefab, transform.position, Quaternion.identity);
            _input.food = false;
        }
    }

}
