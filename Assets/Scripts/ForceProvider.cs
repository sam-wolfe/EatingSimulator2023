using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceProvider : MonoBehaviour {
    
    [SerializeField] private InputManager _input;

    [Tooltip("The starting strength of the cough, depletes as used.")]
    [SerializeField] private float MaxCoughForce = 5;

    private float _coughForce;
    
    [Tooltip("How fast the cough strength depletes.")]
    [SerializeField] private float CoughDepletionRate = 1;

    [Tooltip("How fast the cough strength regenerates.")]
    [SerializeField] private float CoughRegenRate = 0.75f;
    
    private void Start() {
        _input.CoughPerformed += HandleCough;
        _coughForce = MaxCoughForce;
    }

    private void HandleCough() {
        _coughForce -= CoughDepletionRate;
        Clamp();
    }

    void Update() {
        _coughForce += CoughRegenRate / 10;
        Clamp();
    }

    void Clamp() {
        // Allow min to go into negatives, making it so if you completely deplete it,
        // it takes a few seconds before you get any force back at all.
        _coughForce = Mathf.Clamp(_coughForce, -5f, MaxCoughForce);
    }

    public float get() {
        return Mathf.Clamp(_coughForce, 0, MaxCoughForce);
    }
}
