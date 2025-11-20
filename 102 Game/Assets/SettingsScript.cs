using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    bool open = false;

    public GameObject settingsPanel;

    public Slider musicSlider;
    public Slider soundEffectsSlider;

    SoundManagerScript soundManagerScript;

    public void OpenCloseSettingsPanel()
    {
        if (open)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
        }

        open = !open;
    }

    private void Start()
    {
        soundManagerScript = DontDestroyScript.instance.transform.Find("SoundManager").GetComponent<SoundManagerScript>();
        float musicSliderInitialValue = soundManagerScript.musicVolume;
        float soundEffectsSliderInitialValue = soundManagerScript.soundFXVolume;


        InitializeSliderValue(musicSlider, musicSliderInitialValue);
        InitializeSliderValue(soundEffectsSlider, soundEffectsSliderInitialValue);
    }

    void InitializeSliderValue(Slider slider, float value)
    {
        slider.value = value;
    }

    public void OnMusicVolumeChanged(float newVolume)
    {
        AudioSource musicSrc = soundManagerScript.musicSrc;
        soundManagerScript.ChangeVolume(musicSrc, newVolume);
    }

    public void OnSoundEffectVolumeChanged(float newVolume)
    {
        AudioSource soundFXSrc = soundManagerScript.soundFXSrc;
        soundManagerScript.ChangeVolume(soundFXSrc, newVolume);

        AudioSource typingSrc = soundManagerScript.typingSrc;

        float decreasedVolume = newVolume * soundManagerScript.typingSrcOffset;
        decreasedVolume = Mathf.Min(1, decreasedVolume);

        soundManagerScript.ChangeVolume(typingSrc, decreasedVolume);




    }
}
