using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Random = UnityEngine.Random;

public class Throat : MonoBehaviour {

    public event Action OnChoke;
    public event Action<int> OnAirDeplete;
    public event Action OnClearBlockage;
    
    public List<FoodInstance> foodList;

    private int chokesLeft;
    private bool isChoking;
    [SerializeField] private int maxAirLeft = 10;
    private int airLeft = 10;
    
    // Audio

    [SerializeField] private AudioSource _audio;
    [SerializeField] private SoundList clips;
    [SerializeField] private AudioClip ChokeStart;

    //------------
    [SerializeField] private TextMeshProUGUI chokingText;
    [SerializeField] private GameObject chokingTextParent;

    private void OnTriggerEnter2D(Collider2D other) {
        FoodInstance food = other.GetComponent<FoodInstance>();
        if (food != null && !food.IsChewed()) {
            Debug.Log("GACK HEKdsf B SKAAAAAAA.");
            Choke(food);
            _audio.PlayOneShot(ChokeStart);
        }
    }

    public void Choke(FoodInstance food) {
        var f_rb = food.GetComponent<Rigidbody2D>();
        f_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        foodList.Add(food);
        OnChoke?.Invoke();
        // TODO add UI panic
        chokesLeft = Mathf.RoundToInt(Random.Range(8f, 12f));
        isChoking = true;
        airLeft = maxAirLeft;
        OnAirDeplete?.Invoke(airLeft);
        chokingTextParent.SetActive(true);
        StartCoroutine(Choke());
    }
    
    private IEnumerator Choke() {
        while (isChoking) {
            yield return new WaitForSeconds(1f);
            airLeft--;
            OnAirDeplete?.Invoke(airLeft);
        }
        chokingTextParent.SetActive(false);
    }

    private void Update() {
        if (isChoking) {
            chokingTextParent.transform.position = new Vector3(
                chokingTextParent.transform.position.x + Random.Range(-0.5f, 0.5f),
                chokingTextParent.transform.position.y + Random.Range(-0.5f, 0.5f),
                chokingTextParent.transform.position.z);
        }
    }


    public void ProcessChoking() {
        // Returns true if was choking and is now cleared
        if (isChoking) {
            chokesLeft--;
            Debug.Log(chokesLeft);
            if (chokesLeft <= 0) {
                OnClearBlockage?.Invoke();
                isChoking = false;
                foreach (var food in foodList) {
                    if (food != null) {
                        food.BlowUp();
                    }
                }
            }
        }

    }

}
