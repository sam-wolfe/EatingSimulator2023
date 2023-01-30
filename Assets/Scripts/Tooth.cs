using System;
using UnityEngine;
using UnityEngine.UI;

public class Tooth : MonoBehaviour {

    public event Action<GameObject> OnToothTouch;
    public event Action<GameObject> OnToothClamp;

    [SerializeField] private SpriteRenderer topToothSprite;
    [SerializeField] private SpriteRenderer bottomToothSprite;
    [SerializeField] private SpriteRenderer t1;
    [SerializeField] private SpriteRenderer t2;
    [SerializeField] private SpriteRenderer t3;
    [SerializeField] private SpriteRenderer t4;
    [SerializeField] private SpriteRenderer t5;
    [SerializeField] private SpriteRenderer t6;
    [SerializeField] private SpriteRenderer t7;

    [SerializeField] private Sprite brokenTeeth;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip brokenteeth;
    [SerializeField] private ParticleSystem particleSystem1;
    [SerializeField] private ParticleSystem particleSystem2;
    [SerializeField] private ParticleSystem particleSystem3;
    

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
            particleSystem1.Play();
            particleSystem2.Play();
            particleSystem3.Play();
        }
    }

    public void BreakTeeth() {
        topToothSprite.sprite = brokenTeeth;
        bottomToothSprite.sprite = brokenTeeth;
        t1.sprite = brokenTeeth;
        t2.sprite = brokenTeeth;
        t3.sprite = brokenTeeth;
        t4.sprite = brokenTeeth;
        t5.sprite = brokenTeeth;
        t6.sprite = brokenTeeth;
        t7.sprite = brokenTeeth;
        broken = true;
    }

    public void DestroyTeeth() {
        
    }


}
