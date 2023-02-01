using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    [SerializeField] private PlayerInput _input;

    public Vector2 tongue;
    public Vector2 fork;
    public float jaw = 0f;
    public bool cough;
    public bool food;

    public event Action CoughPerformed;
    public event Action SwallowPerformed;
    public event Action MoveFoodPerformed;
    
    public void OnTongue(InputAction.CallbackContext context) {
        tongue = context.ReadValue<Vector2>();
    }

    public void OnJaw(InputAction.CallbackContext context) {
        jaw = context.ReadValue<float>();
        // Debug.Log(jaw);
    }
    
    public void SpawnFood(InputAction.CallbackContext context) {
        switch (context.phase) {
            case InputActionPhase.Started:
                food = true;
                break;
            case InputActionPhase.Canceled:
                food = false;
                break;
        }
    }
    
    public void OnCough(InputAction.CallbackContext context) {
        switch (context.phase) {
            case InputActionPhase.Started:
                CoughPerformed?.Invoke();
                cough = true;
                break;
            case InputActionPhase.Canceled:
                cough = false;
                break;
        }
    }
    
    public void OnMoveFood(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started){
            MoveFoodPerformed?.Invoke();
            // Debug.Log("Get back there!");
        }
    }
    
    public void OnSwallow(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started){
            SwallowPerformed?.Invoke();
            Debug.Log("GULP!");
            // TODO add swallow mechanic
        }
    }

    public void OnFork(InputAction.CallbackContext context) {
        fork = context.ReadValue<Vector2>();
    }

}
