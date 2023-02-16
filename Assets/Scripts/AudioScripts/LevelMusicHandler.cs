using UnityEngine;

public class LevelMusicHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;

    private bool _hasMusicStarted = false;

    private void Update()
    {
        if(Timer._hasStarted && !_hasMusicStarted)
        {
            _musicSource.Play();
            _hasMusicStarted = true;
        }
    }
}
