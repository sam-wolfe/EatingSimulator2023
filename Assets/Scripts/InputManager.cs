using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    [SerializeField] private PlayerInput _input;

    public Vector2 tongue;
    
    public void OnTongue(InputAction.CallbackContext context) {
        tongue = context.ReadValue<Vector2>();
    }

}
