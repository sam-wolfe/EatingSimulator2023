using System;
using UnityEngine;

public class FoodInstance : MonoBehaviour {

    [SerializeField] public Food foodSettings; // Out of time, sue me, its public now
    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;
    
    private int chews;

    public event Action OnTongueTouch;

    private void OnEnable() {

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

    public void BlowUp() {
        // TODO add particle effect
        // TODO play sound effect

        gameObject.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Tongue")) {
            OnTongueTouch?.Invoke();
        }
    }

}
