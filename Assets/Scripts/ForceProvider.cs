using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceProvider : MonoBehaviour {
    
    [Tooltip("The starting strength of the cough, depletes as used.")]
    [SerializeField] private int MaxCoughForce;
    
    [Tooltip("How fast the cough strength depletes.")]
    [SerializeField] private int CoughDepletionRate;

    [Tooltip("How fast the cough strength regenerates.")]
    [SerializeField] private int CoughRegenRate;

    void Update() {
        
    }
}
