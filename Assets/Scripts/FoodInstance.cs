using System;
using DefaultNamespace;
using UnityEngine;

public class FoodInstance : MonoBehaviour {

    [SerializeField] public Food foodSettings; // Out of time, sue me, its public now
    [SerializeField] public Tooth toothsettings; // Out of time, sue me, its public now
    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;
    
    private int chews;

    private void OnEnable() {
        // _chewHandler = FindObjectOfType<ChewHandler>();
        // _chewHandler.OnChew += Chew;

        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        
        transform.localScale = new Vector3(foodSettings.radius, foodSettings.radius, foodSettings.radius);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90f, transform.eulerAngles.z);
        chews = foodSettings.chewCount;
        if (toothsettings.broken) {
            chews = chews * 2;
        }
    }

    public void Chew() {
        if (chews > 0) {
            chews--;
        }
        else {
            _meshFilter.mesh = foodSettings.chewedMesh;
            _meshRenderer.material = foodSettings.chewedMaterial;
        }
    }

    public bool IsChewed() {
        return chews == 0;
    }

    public void BlowUp() {
        // TODO add particle effect
        // TODO play sound effect

        gameObject.SetActive(false);
    }
    
    // private void OnCollisionEnter2D(Collision2D col) {
    //     IFoodProcessor foodProcessor = col.gameObject.GetComponent<IFoodProcessor>();
    //     if (foodProcessor != null) {
    //         foodProcessor.IncomingFood(this);
    //         Debug.Log("apple");
    //     }
    // }

}
