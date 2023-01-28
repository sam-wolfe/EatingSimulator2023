using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    [SerializeField] private PlayerInput _input;

    public Vector2 tongue;
    public float jaw = 0f;
    
    public void OnTongue(InputAction.CallbackContext context) {
        tongue = context.ReadValue<Vector2>();
    }

    public void OnJaw(InputAction.CallbackContext context) {
        jaw = context.ReadValue<float>();
        Debug.Log(jaw);
    }

}
