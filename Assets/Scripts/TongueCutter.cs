using UnityEngine;

public class TongueCutter : MonoBehaviour {

    public bool tonguePresent;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Tongue")) {
            tonguePresent = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Tongue")) {
            tonguePresent = false;
        }
    }

}
