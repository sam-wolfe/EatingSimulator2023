using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkDetector : MonoBehaviour {

    public bool forkPresent;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Fork")) {
            forkPresent = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Fork")) {
            forkPresent = false;
        }
    }
}
