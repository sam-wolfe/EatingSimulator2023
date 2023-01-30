using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[CreateAssetMenu(fileName = "SoundList", menuName = "ScriptableObjects/SoundList")]
public class SoundList : ScriptableObject {

    [SerializeField] private List<AudioClip> sounds;
    
    public AudioClip getRandom() {

        if (sounds.Count == 0) return null;

        var random = new Random();
        
        return sounds[random.Next(sounds.Count)];
        
    }

}