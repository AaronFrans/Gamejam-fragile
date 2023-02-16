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

    [SerializeField]
    public AudioMixer _mixer;

    // Start is called before the first frame update
    void Start()
    {

        _masterSlider.value = 1f;
        _backgroundSlider.value = 1f;
        _ambientSlider.value = 1f;
        _soundEffectSlider.value = 1f;
    }


    // Update is called once per frame
    void Update()
    {
        _mixer.SetFloat("Master", _masterSlider.value);
        _mixer.SetFloat("Music", _backgroundSlider.value);
        _mixer.SetFloat("Ambi", _ambientSlider.value);
        _mixer.SetFloat("SFX", _soundEffectSlider.value);
    }

    public void UpdateMaster(float newVal)
    {
        _mixer.SetFloat("Master", newVal);
    }

    public void UpdateMusic(float newVal)
    {
        _mixer.SetFloat("Music", newVal);
    }
    public void UpdateAmbi(float newVal)
    {
        _mixer.SetFloat("Ambi", newVal);
    }
    public void UpdateSFX(float newVal)
    {
        _mixer.SetFloat("SFX", newVal);
    }
}
