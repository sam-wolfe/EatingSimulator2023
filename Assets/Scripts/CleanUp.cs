using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour {

    [SerializeField] private float delay = 5;
    
    void Start() {
        Invoke("KillMe", delay);
    }

    void KillMe() {
        Destroy(gameObject);
    }
}
