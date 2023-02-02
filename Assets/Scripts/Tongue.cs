using System;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    [SerializeField] private InputManager _input;
    [SerializeField] private float speed;
    public bool isCut;
    
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField] Sprite tongueSprite;
    [SerializeField] GameObject tongueDebriPrefab;
    [SerializeField] ParticleSystem tongueBlood;
    [SerializeField] SpriteRenderer tongueSpriteRenderer;
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _tongueCutSound;
    
    public event Action OnTongueCut;
    
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rigidbody2D.AddForce(_input.tongue * speed * Time.deltaTime, ForceMode2D.Force);
    }

    public void CutTongue() {
        isCut = true;
        tongueSpriteRenderer.sprite = tongueSprite;
        var debris = Instantiate(tongueDebriPrefab, transform.position, Quaternion.identity);
        var bloodParticles = Instantiate(tongueBlood, transform.position, Quaternion.identity);
        var bloodParticles2 = Instantiate(tongueBlood, transform.position, Quaternion.identity);
        bloodParticles.transform.parent = debris.transform; 
        bloodParticles.Play();
        bloodParticles2.transform.parent = transform;
        bloodParticles2.Play();
        _audioSource.PlayOneShot(_tongueCutSound);
        OnTongueCut?.Invoke();
    }
}
