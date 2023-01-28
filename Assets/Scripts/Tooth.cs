using System;
using UnityEngine;

public class Tooth : MonoBehaviour {

    public event Action<GameObject> OnToothTouch;
    public event Action<GameObject> OnToothClamp;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Tooth") {
            Debug.Log("Injury");
            OnToothTouch?.Invoke(other.gameObject);
        } else if (other.tag == "Gums") {
            Debug.Log("Amputation");
            OnToothClamp?.Invoke(other.gameObject);
        }
    }

    public void DamageTeeth() {
        // Nothing yet
    }

    public void DestroyTeeth() {
        
    }


}
