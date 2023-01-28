using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawReset : MonoBehaviour {
    
    [SerializeField] private InputManager _input;

    [SerializeField]
    float jawSpeed = 5;
    
    [SerializeField] private Vector3 closedPosition;

    
    private Vector3 _initialPosition;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _initialPosition = transform.position;

    }

    void Update()
    {
        _rb.MovePosition(Vector2.Lerp(_initialPosition, closedPosition, _input.jaw));
    }
}
