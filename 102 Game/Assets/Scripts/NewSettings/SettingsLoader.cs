using UnityEngine;
using UnityEngine.UI;

public class SettingsLoader : MonoBehaviour
{
    public MainSettingsScript settingsScript;

    public Slider masterSlider, musicSlider, sfxSlider;

    public Toggle fullScreenToggle;

    public float musicVolume
    {
        get { return PlayerPrefs.GetFloat("musicVolume", 5); }
        set { PlayerPrefs.SetFloat("musicVolume", value); }
    }

    public float masterVolume
    {
        get { return PlayerPrefs.GetFloat("masterVolume", 5); }
        set { PlayerPrefs.SetFloat("masterVolume", value); }
    }

    public float sfxVolume
    {
        get { return PlayerPrefs.GetFloat("sfxVolume", 5); }
        set { PlayerPrefs.SetFloat("sfxVolume", value); }
    }

    public int fullScreenToggled
    {
        get { return PlayerPrefs.GetInt("fullScreenToggled", 0); }
        set { PlayerPrefs.SetInt("fullScreenToggled", value);  }
    }



    private void Start()
    {
        InitializeSettingsValues();
    }

    private void InitializeSettingsValues()
    {
        float masterVolume = this.masterVolume;
        masterSlider.value = masterVolume;
        settingsScript.OnMasterVolumeChanged(masterVolume);

        float musicVolume = this.musicVolume;
        musicSlider.value = musicVolume;
        settingsScript.OnMusicVolumeChanged(musicVolume);

        float sfxVolume = this.sfxVolume;
        sfxSlider.value = sfxVolume;
        settingsScript.OnSFXVolumeChanged(sfxVolume);

        int toggledValue = fullScreenToggled;
        bool toggled = toggledValue == 0 ? false : true;
        fullScreenToggle.isOn = toggled;
        settingsScript.ToggleFullScreen(toggled);
    }
}
