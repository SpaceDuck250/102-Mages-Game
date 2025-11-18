using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{
    [SerializeField] Image timerImage;

    float startTime;
    float timer;

    bool timerOn = false;

    private void Update()
    {
        if (!timerOn)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0;
            timerOn = false;
            CloseTimer();
        }

        timerImage.fillAmount = timer / startTime;

    }

    public void StartTimer(float startTime)
    {
        gameObject.SetActive(true);
        timerImage.fillAmount = 1;

        timer = startTime;
        this.startTime = startTime;

        timerOn = true;
    }

    public void CloseTimer()
    {
        gameObject.SetActive(false);
    }


}
