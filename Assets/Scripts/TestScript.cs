using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    [SerializeField] private InputManager _input;
    [SerializeField] private float speed;
    
    private Rigidbody2D _rigidbody2D;
    
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.AddForce(_input.tongue * speed * Time.deltaTime, ForceMode2D.Force);
    }
}
