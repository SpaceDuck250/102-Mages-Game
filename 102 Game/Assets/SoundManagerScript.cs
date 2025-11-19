using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource musicSrc;
    public float musicVolume;

    public AudioSource soundFXSrc;
    public float soundFXVolume;

    public AudioSource typingSrc;
    public float typingSrcVolume;

    public AudioClip typingClip;

    public AudioClip musicClip1, battleMusic;

    public AudioClip weakHit, normalHit, strongHit;
    public AudioClip enemyHit;

    private void Start()
    {
        PlayMusic(musicClip1);
        ChangeVolume(musicSrc, musicVolume);

        typingSrc.loop = true;
        typingSrc.clip = typingClip;
        typingSrc.Play();
        PauseTyping();
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicSrc.Stop();
        musicSrc.loop = true;
        musicSrc.clip = musicClip;
        musicSrc.Play();
    }

    public void ChangeVolume(AudioSource src, float newVolume)
    {
        src.volume = newVolume;
        UpdateStoredVolumeValues();

    }

    void UpdateStoredVolumeValues()
    {
        musicVolume = musicSrc.volume;
        typingSrcVolume = typingSrc.volume;
    }

    public void PlaySoundFX(AudioClip clip)
    {
        soundFXSrc.PlayOneShot(clip);
    }

    public void PauseTyping()
    {
        typingSrc.Pause();
    }

    public void UnpauseTyping()
    {
        typingSrc.UnPause();
    }


}
