using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueCutter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Tooth") {
            Debug.Log("Amputation");
        }
    }

}
