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


    [SerializeField]
    public AudioMixer _mixer;

    // Start is called before the first frame update
    void Start()
    {
        _mixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("Master", 1)) * 20);
        _mixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("Music", 1)) * 20);
        _mixer.SetFloat("Ambi", Mathf.Log10(PlayerPrefs.GetFloat("Ambi", 1)) * 20);
        _mixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SFX", 1)) * 20);
    }

    public void UpdateMaster(float newVal)
    {
        UpdateMixer("Master", newVal);
    }

    public void UpdateMusic(float newVal)
    {
        UpdateMixer("Music", newVal);
    }

    public void UpdateAmbi(float newVal)
    {
        UpdateMixer("Ambi", newVal);
    }
    public void UpdateSFX(float newVal)
    {
        UpdateMixer("SFX", newVal);
    }
    private void UpdateMixer(string mixerName ,float newVal)
    {
        if (newVal == 0)
        {
            _mixer.SetFloat(mixerName, -80);
        }
        else
        {
            _mixer.SetFloat(mixerName, Mathf.Log10(newVal) * 20);
        }
        PlayerPrefs.SetFloat(mixerName, newVal);
        PlayerPrefs.Save();
    }

}
