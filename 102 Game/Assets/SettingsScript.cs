using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    bool open = false;

    public GameObject settingsPanel;

    public Slider musicSlider;

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
        print(musicSliderInitialValue);

        InitializeSliderValue(musicSlider, musicSliderInitialValue);
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
}
