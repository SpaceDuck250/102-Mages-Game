using UnityEngine;
using UnityEngine.Audio;

public class MainSettingsScript : MonoBehaviour
{
    public GameObject settingsPanel;

    private bool opened = false;

    public AudioMixer audioMixer;

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
        PlayerPrefs.SetFloat("masterVolume", newVolume);
    }

    public void OnMusicVolumeChanged(float newVolume)
    {
        audioMixer.SetFloat("musicVolume", newVolume);
        PlayerPrefs.SetFloat("musicVolume", newVolume);
    }

    public void OnSFXVolumeChanged(float newVolume)
    {
        audioMixer.SetFloat("sfxVolume", newVolume);
        PlayerPrefs.SetFloat("sfxVolume", newVolume);
    }

    public void ToggleFullScreen(bool toggled)
    {
        Screen.fullScreen = toggled;
        print(toggled);

        int toggledValue = toggled ? 1 : 0;

        PlayerPrefs.SetInt("fullScreenToggled", toggledValue);
    }
}
