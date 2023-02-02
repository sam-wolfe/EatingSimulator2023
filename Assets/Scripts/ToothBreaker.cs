using System.Collections.Generic;
using UnityEngine;

public class ToothBreaker : MonoBehaviour {

    [SerializeField] private List<ToothBreak> _teeth;
    [SerializeField] private Tooth _tooth;

    public void BreakTeeth() {
        foreach (var tooth in _teeth) {
            tooth.Break();
        }
        _tooth.BreakTeeth();
    }

}
