using System;
using UnityEngine;

public class ForkKillWall : MonoBehaviour {
    
    [SerializeField] Fork _fork;
    [SerializeField] private GameObject _bloodPrefab;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private GameManager _gameManager;
    
    public event Action OnForkTouch;
    
    private void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == "Fork") {
                InitiateDeathSequence();
            } 
    }

    private void InitiateDeathSequence() {
        Debug.Log("U R DED LOL.");
        _fork.enabled = false;
        _audioSource.PlayOneShot(_deathSound);
        Instantiate(_bloodPrefab, transform.position, Quaternion.identity);
        _gameManager.Invoke("GameOver", 3f);
        OnForkTouch?.Invoke();
    }
}
