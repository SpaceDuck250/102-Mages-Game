using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource musicSrc;
    public float musicVolume;

    public AudioSource battleMusicSrc;

    public float battleMusicVolumeOffset;
    public float battleMusicVolume
    {
        get { float battleMusicVolume = ReturnDecreasedVolume(musicVolume, battleMusicVolumeOffset); return battleMusicVolume; }
    }

    public AudioSource soundFXSrc;
    public float soundFXVolume;

    public AudioSource typingSrc;

    public float typingSrcOffset;

    public float typingSrcVolume
    {
        get { float typingVolume = ReturnDecreasedVolume(soundFXVolume, typingSrcOffset); return typingVolume; }
    }



    public AudioClip typingClip;

    public AudioClip musicClip1, musicClip2, battleMusic;

    public AudioClip weakHit, normalHit, strongHit;
    public AudioClip enemyHit;

    private void Start()
    {
        InitializeVolumes();

        PlayMusic(musicSrc, musicClip1);

        typingSrc.loop = true;
        typingSrc.clip = typingClip;
        typingSrc.Play();
        PauseTyping();
    }

    public void InitializeVolumes()
    {
        ChangeVolume(musicSrc, musicVolume);
        ChangeVolume(soundFXSrc, soundFXVolume);
        ChangeVolume(typingSrc, typingSrcVolume);
        ChangeVolume(battleMusicSrc, battleMusicVolume);
    }

    public void PlayMusic(AudioSource musicSrc, AudioClip musicClip)
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

    public void UpdateStoredVolumeValues()
    {
        musicVolume = musicSrc.volume;
        soundFXVolume = soundFXSrc.volume;
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

    public float ReturnDecreasedVolume(float volume, float offset)
    {
        float decreasedVolume = volume * offset;

        return decreasedVolume;
    }


}
