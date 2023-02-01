using System.Collections.Generic;
using UnityEngine;

public class ToothBreaker : MonoBehaviour {

    [SerializeField] private List<ToothBreak> _teeth;

    public void BreakTeeth() {
        foreach (var tooth in _teeth) {
            tooth.Break();
        }
    }
    
    void Start() {
        
    }

    void Update() {
        
    }
}
