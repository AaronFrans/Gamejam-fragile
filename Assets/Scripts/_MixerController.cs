using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class _MixerController : MonoBehaviour
{


    //[SerializeField] private AudioMixer _audioMixer;

    public Slider _masterSlider, _backgroundSlider, _ambientSlider, _soundEffectSlider;
    private float _masterFloat, _backgroundFloat, _ambientFloat, _soundEffectFloat;

    public AudioSource _backgroundAudio;
    public AudioSource[] _soundeffectaudio;

    // Start is called before the first frame update
    void Start()
    {
        _masterFloat = .25f;
        _backgroundFloat = .75f;
        _ambientFloat = .75f;
        _soundEffectFloat = .75f;

        _masterSlider.value = _masterFloat;
        _backgroundSlider.value = _backgroundFloat;
        _ambientSlider.value = _ambientFloat;
        _soundEffectSlider.value = _soundEffectFloat;

        
    }

    public void UpdateSound()
    {
        _backgroundAudio.volume = _backgroundSlider.value;

        for(int i = 0; i < _soundeffectaudio.Length; ++i)
        {
            _soundeffectaudio[i].volume = _soundEffectSlider.value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float sliderValue)
    {
        //_audioMixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
    }
}
