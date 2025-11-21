using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShieldScript : MonoBehaviour
{
    public BlockAttackScript playerBlockAttackScript;
    public TextMeshProUGUI timerText;

    public Image shieldImage;

    public float timer;
    private float blockTime;

    private bool timerOn = false;

    private void Start()
    {
        playerBlockAttackScript.onBlock += OnBlock;

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        playerBlockAttackScript.onBlock -= OnBlock;

    }

    private void Update()
    {
        if (!timerOn)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            timerOn = false;

            gameObject.SetActive(false);
        }

        float roundedTime = (float)Math.Round(timer, 2);
        SetTimerText(roundedTime);

    }

    private void OnBlock(float blockTime)
    {
        gameObject.SetActive(true);

        timer = blockTime;
        timerOn = true;
    }

    private void SetTimerText(float timeLeft)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);

        string formattedText = timeSpan.ToString(@"s\.ff");
        timerText.text = formattedText;
    }
}
