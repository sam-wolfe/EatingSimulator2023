using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "ScriptableObjects/Food")]
public class Food : ScriptableObject {

    public GameObject prefab;
    public int chewCount = 2;
    public float radius = 0.5f;
    public Mesh chewedMesh;
    public Material chewedMaterial;


}
