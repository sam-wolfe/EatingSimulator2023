using UnityEngine;

public class TestScript : MonoBehaviour {

    [SerializeField] private Food foodItem;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            Instantiate(foodItem.prefab, transform.position, Quaternion.identity);
        }
    }

}
