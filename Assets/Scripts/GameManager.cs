using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] private Throat _throat;
    [SerializeField] private HungerManager _hungerManager;

    [SerializeField] private GameObject gameOverUi;
    
    // Audio

    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip airDeathClip;
    [SerializeField] private AudioClip foodDeathClip;

    
    void Start() {
        _throat.OnAirDeplete += CheckForGameOverAir;
        _hungerManager.OnStarve += CheckForGameOverFood;
    }

    void Update()
    {
        
    }

    private void CheckForGameOverAir(int airLeft) {
        if (airLeft <= 0) {
            GameOver();
            _audio.PlayOneShot(airDeathClip);
        }
    }
    
    private void CheckForGameOverFood(int foodLevel) {
        if (foodLevel <= 0) {
            GameOver();
            _audio.PlayOneShot(foodDeathClip);
        }
    }

    public void GameOver() {
        Debug.Log("Game Over");
        gameOverUi.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
