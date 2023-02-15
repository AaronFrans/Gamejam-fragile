using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Patch")]
public class Patch : ScriptableObject
{
    public AudioClip[] audioClips;
    [Range(0, 1)] public float maxVolume = 1;
    [Range(0, 1)] public float minVolume = 1;
    [Range(-3, 3)] public float maxPitch = 1;
    [Range(-3, 3)] public float minPitch = 1;

    private void OnValidate()
    {
        if (minVolume > maxVolume)
        {
            minVolume = maxVolume;
        }

        if (minPitch > maxPitch)
        {
            minPitch = maxPitch;
        }
    }

    private AudioClip GetRandomClip()
    {
        return audioClips[Random.Range(0, audioClips.Length)];
    }

    public void Play(AudioSource source)
    {
        source.clip = GetRandomClip();
        source.volume = Random.Range(minVolume, maxVolume);
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
    }

    public void PlayOneShot(AudioSource source)
    {
        AudioClip clip = GetRandomClip();
        source.PlayOneShot(clip);
    }
}