using UnityEngine;

public class ForkKillWall : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == "Fork") {
                InitiateDeathSequence();
            } 
    }

    private void InitiateDeathSequence() {
        // TODO
        Debug.Log("U R DED LOL.");
    }
}
