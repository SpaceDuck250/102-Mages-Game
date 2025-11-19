using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public TextMeshProUGUI sliderName;

    public Image instantHealthBar;
    public Image chaserHealthBar;

    bool canChase = false;

    public static float smoothValue;

    private void Start()
    {
        smoothValue = 3;
    }

    private void Update()
    {
        if (!canChase)
        {
            return;
        }

        if (instantHealthBar.fillAmount != chaserHealthBar.fillAmount)
        {
            chaserHealthBar.fillAmount = Mathf.Lerp(chaserHealthBar.fillAmount, instantHealthBar.fillAmount, smoothValue * Time.deltaTime);
        }
    }

    public void InitializeSlider(string name)
    {
        instantHealthBar.fillAmount = 1;
        chaserHealthBar.fillAmount = 1;

        sliderName.text = name;
    }


    public void TakeDamage(float health, float maxHealth)
    {
        canChase = false;

        float CalculatedHealth = health / maxHealth;

        instantHealthBar.fillAmount = CalculatedHealth;

        float waitTime = 0.4f;
        Invoke("WaitUntilCanChase", waitTime);
    }

    private void WaitUntilCanChase()
    {
        canChase = true;
    }
}
