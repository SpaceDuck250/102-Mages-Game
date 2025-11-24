using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource musicSrc;

    public AudioSource battleMusicSrc;

    public AudioSource soundFXSrc;

    public AudioSource typingSrc;

    public AudioClip typingClip;

    public AudioClip musicClip1, musicClip2, battleMusic;

    public AudioClip weakHit, normalHit, strongHit;
    public AudioClip enemyHit;

    private void Start()
    {
        PlayMusic(musicSrc, musicClip1);

        typingSrc.loop = true;
        typingSrc.clip = typingClip;
        typingSrc.Play();
        PauseTyping();
    }

    public void PlayMusic(AudioSource musicSrc, AudioClip musicClip)
    {
        musicSrc.Stop();
        musicSrc.loop = true;
        musicSrc.clip = musicClip;
        musicSrc.Play();
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
