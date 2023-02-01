using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour {
    
    [SerializeField] private InputManager _input;
    [SerializeField] private float speed;
    [SerializeField] private GameObject _foodPosition;
    
    private Rigidbody2D _rigidbody2D;
    private bool _isLoaded;
    // private FoodInstance _loadedFood;
    private Rigidbody2D _foodBody;
    
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() {

        Vector2 newPos = transform.position;
        newPos.x += (_input.fork.x * speed * Time.deltaTime);
        _rigidbody2D.MovePosition(newPos);

        if (_isLoaded) {
            // if (_loadedFood == null) {
            //     throw new Exception("Food loaded flag is set, but _loadedFood is null!");
            // }
            if (_foodBody == null) {
                throw new Exception("Food loaded flag is set, but _foodBody is null!");
            }
            
            _foodBody.MovePosition(_foodPosition.transform.position);

        }
    }

    public void LoadFork(Food food) {
        if (!_isLoaded) {
            Debug.Log("Add food to fork.");

            var loadedFood = Instantiate(
                food.prefab, _foodPosition.transform.position, Quaternion.identity);
        
            _foodBody = loadedFood.GetComponent<Rigidbody2D>();
            _foodBody.freezeRotation = true;

            FoodInstance foodInstance = loadedFood.GetComponent<FoodInstance>();

            foodInstance.OnTongueTouch += UnloadFork;

            _isLoaded = true;
        } else {
            Debug.Log("Fork already full");
        }

    }

    public void UnloadFork() {
        _isLoaded = false;

        _foodBody.gameObject.GetComponent<FoodInstance>().OnTongueTouch -= UnloadFork;
        
        _foodBody.freezeRotation = false;
        _foodBody = null;
    }
}
