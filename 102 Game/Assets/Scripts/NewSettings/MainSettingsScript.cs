using UnityEngine;
using UnityEngine.Audio;

public class MainSettingsScript : MonoBehaviour
{
    public GameObject settingsPanel;

    private bool opened = false;

    public AudioMixer audioMixer;
    public SettingsLoader settingsLoader;


    public void OpenCloseSettingsPanel()
    {
        if (opened)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
        }

        opened = !opened;
    }

    public void OnMasterVolumeChanged(float newVolume)
    {
        audioMixer.SetFloat("masterVolume", newVolume);
        settingsLoader.masterVolume = newVolume;
    }

    public void OnMusicVolumeChanged(float newVolume)
    {
        audioMixer.SetFloat("musicVolume", newVolume);
        settingsLoader.musicVolume = newVolume;

    }

    public void OnSFXVolumeChanged(float newVolume)
    {
        audioMixer.SetFloat("sfxVolume", newVolume);
        settingsLoader.sfxVolume = newVolume;
    }

    public void ToggleFullScreen(bool toggled)
    {
        Screen.fullScreen = toggled;
        print(toggled);

        int toggledValue = toggled ? 1 : 0;

        settingsLoader.fullScreenToggled = toggledValue;
    }
}
