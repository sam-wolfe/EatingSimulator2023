using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooth : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Tooth") {
            Debug.Log("Injury");
        } else if (other.tag == "Gums") {
            Debug.Log("Amputation");
        }
    }


}
