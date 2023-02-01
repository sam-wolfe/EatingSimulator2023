using System;
using UnityEngine;

public class Tooth : MonoBehaviour {

    public event Action<GameObject> OnToothTouch;
    public event Action<GameObject> OnToothClamp;

    [SerializeField] private SpriteRenderer topToothSprite;
    [SerializeField] private SpriteRenderer bottomToothSprite;

    [SerializeField] private Sprite brokenTeeth;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip brokenteeth;

    [SerializeField] private ToothBreaker _toothBreaker;
    

    private int health = 3;
    public bool broken = false;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Tooth") {
            Debug.Log("Injury");
            OnToothTouch?.Invoke(other.gameObject);
        } else if (other.tag == "Gums") {
            Debug.Log("Amputation");
            OnToothClamp?.Invoke(other.gameObject);
            DamageTeeth();
        }
    }

    public void DamageTeeth() {
        health--;
        if (health <= 0 && !broken) {
            BreakTeeth();
            Debug.Log("Teeth broken");
            _audioSource.PlayOneShot(brokenteeth);
            

        } else if (broken) {
            // TODO maybe only play randomly?
            _audioSource.PlayOneShot(brokenteeth);
        }
    }

    public void BreakTeeth() {
        topToothSprite.sprite = brokenTeeth;
        bottomToothSprite.sprite = brokenTeeth;
        broken = true;
        _toothBreaker.BreakTeeth();
    }

}
