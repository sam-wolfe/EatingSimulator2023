using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueReset : MonoBehaviour
{

    [SerializeField] float _tongueResetSpeed = 10f;

    private Rigidbody2D _rb;
    private void Start() {
        _rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        _rb.AddForce(new Vector2(-_tongueResetSpeed * Time.deltaTime, 0f));
    }
}
