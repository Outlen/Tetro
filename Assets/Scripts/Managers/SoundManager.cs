using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicRoamSource, _musicFightSource, _effectsSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }


    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    public void PlayRoamBGM()
    {
        _musicRoamSource.Play();
    }

    public void PauseRoamBGM()
    {
        _musicRoamSource.Pause();
    }

    public void PlayFightBGM()
    {
        _musicFightSource.Play();
    }

    public void PauseFightBGM()
    {
        _musicFightSource.Pause();
    }

}
