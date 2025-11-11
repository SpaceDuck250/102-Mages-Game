using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] Image healthSlider;
    [SerializeField] TextMeshProUGUI sliderName;

    public void InitializeSlider(string name)
    {
        healthSlider.fillAmount = 1;
        sliderName.text = name;
    }

    public void OnHealthChanged(float health, float maxHealth)
    {
        float healthPercentage = health / maxHealth;
        healthSlider.fillAmount = healthPercentage;
    }
}
