using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour {
    
    [SerializeField] private InputManager _input;
    [SerializeField] private float speed;
    [SerializeField] private GameObject _foodPosition;
    
    private Rigidbody2D _rigidbody2D;
    private bool _isLoaded;
    
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() {

        Vector2 newPos = transform.position;
        newPos.x += (_input.fork.x * speed * Time.deltaTime);
        _rigidbody2D.MovePosition(newPos);
    }

    public void LoadFork(Food food) {
        Debug.Log("Add food to fork.");

        Instantiate(food.prefab, _foodPosition.transform.position, Quaternion.identity);
        _isLoaded = true;
    }

    public void UnloadFork() {
        // TODO figure out how to unload fork
        _isLoaded = false;
    }
}
