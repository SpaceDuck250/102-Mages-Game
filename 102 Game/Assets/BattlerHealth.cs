using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public bool dead = false;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
            dead = true;
        }
    }

    public void Revive()
    {
        health = maxHealth;
        dead = false;
    }

   
}
