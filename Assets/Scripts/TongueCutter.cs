using UnityEngine;

public class TongueCutter : MonoBehaviour {

    [SerializeField] private Tooth tooth;

    private void Start() {
        tooth.OnToothTouch += checkDamageTongue;
        tooth.OnToothClamp += checkDestroyTongue;
    }

    private void checkDestroyTongue(GameObject tooth) {
        // Don't need tooth in this method
        
        // TODO if tongue in range, destroy
    }
    
    private void checkDamageTongue(GameObject tooth) {
        // Don't need tooth in this method
        
        // TODO if tongue in range, damage

    }

}
