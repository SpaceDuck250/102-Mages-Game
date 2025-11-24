using UnityEngine;
using UnityEngine.UI;

public class SettingsLoader : MonoBehaviour
{
    public MainSettingsScript settingsScript;

    public Slider masterSlider, musicSlider, sfxSlider;

    public Toggle fullScreenToggle;

    private void Start()
    {
        InitializeSettingsValues();
    }

    private void InitializeSettingsValues()
    {
        float defaultVolume = masterSlider.maxValue;

        float masterVolume = PlayerPrefs.GetFloat("masterVolume", defaultVolume);
        masterSlider.value = masterVolume;
        settingsScript.OnMasterVolumeChanged(masterVolume);

        float musicVolume = PlayerPrefs.GetFloat("musicVolume", defaultVolume);
        musicSlider.value = musicVolume;
        settingsScript.OnMusicVolumeChanged(musicVolume);

        float sfxVolume = PlayerPrefs.GetFloat("sfxVolume", defaultVolume);
        sfxSlider.value = sfxVolume;
        settingsScript.OnSFXVolumeChanged(sfxVolume);

        int defaultToggledValue = 0;

        int toggledValue = PlayerPrefs.GetInt("fullScreenToggled", defaultToggledValue);
        bool toggled = toggledValue == 0 ? false : true;
        fullScreenToggle.isOn = toggled;
        settingsScript.ToggleFullScreen(toggled);
    }
}
