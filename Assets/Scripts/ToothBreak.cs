using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBreak : MonoBehaviour {
    
    // TODO make prefab for blood
    [SerializeField] private GameObject _bloodPrefab;
    [SerializeField] private GameObject _toothDebriPrefab;
    [SerializeField] private SpriteRenderer _toothSprite;
    [SerializeField] private Sprite brokenTeeth;

    public void Break() {
        _toothSprite.sprite = brokenTeeth;
        if (_toothDebriPrefab != null) {
            Instantiate(_toothDebriPrefab, transform.position, Quaternion.identity);
        }
        if (_bloodPrefab != null) {
            Instantiate(_bloodPrefab, transform.position, Quaternion.identity);
        }
    }
}
