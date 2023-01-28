using System;
using DefaultNamespace;
using UnityEngine;

public class FoodInstance : MonoBehaviour {

    [SerializeField] private Food foodSettings;
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
    
    // private void OnCollisionEnter2D(Collision2D col) {
    //     IFoodProcessor foodProcessor = col.gameObject.GetComponent<IFoodProcessor>();
    //     if (foodProcessor != null) {
    //         foodProcessor.IncomingFood(this);
    //         Debug.Log("apple");
    //     }
    // }

}
