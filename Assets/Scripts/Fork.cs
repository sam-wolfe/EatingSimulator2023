using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour {
    
    [SerializeField] private InputManager _input;
    [SerializeField] private float speed;
    
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

    public void LoadFork() {
        
    }
}
