using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BouncePostProcessing : MonoBehaviour {
    
    // Take a global volume and register to an event, when the event is invoked
    // modulate the intensity of the post processing effect with a sine wave
    // to create a bounce effect that slowly fades out.
    
    [SerializeField] private float _bounceIntensity;
    [SerializeField] private float _bounceSpeed;
    [SerializeField] private float _bounceDecay;
    [SerializeField] private float _bounceMin;
    [SerializeField] private float _bounceMax;
    
    [SerializeField] private Volume _postProcessingVolume;
    [SerializeField] private ForkKillWall _forkKillWall;
    [SerializeField] private Tongue _tongue;
    [SerializeField] private Tooth _tooth;
    
    private float _bounce;

    private LensDistortion _lensDistortion;

    private void Start() {
        _postProcessingVolume.profile.TryGet(out _lensDistortion);
    }

    private void OnEnable() {
        _forkKillWall.OnForkTouch += Bounce;
        _tongue.OnTongueCut += Bounce;
        _tooth.OnTeethBroken += Bounce;
    }
    
    private void OnDisable() {
        _forkKillWall.OnForkTouch -= Bounce;
        _tongue.OnTongueCut -= Bounce;
        _tooth.OnTeethBroken -= Bounce;
    }
    
    private void Bounce() {
        _bounce = _bounceIntensity;
    }
    
    void Update() {
        if (_bounce > 0) {
            _bounce -= _bounceDecay * Time.deltaTime;
            _bounce = Mathf.Clamp(_bounce, _bounceMin, _bounceMax);
            var bounce = Mathf.Sin(Time.time * _bounceSpeed) * _bounce;
            _lensDistortion.intensity.value = bounce;
        }
    }
    
    

}
