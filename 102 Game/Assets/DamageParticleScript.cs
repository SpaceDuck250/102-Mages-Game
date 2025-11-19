using UnityEngine;

public class DamageParticleScript : MonoBehaviour
{
    public float timeAlive;
    float timer;

    private void Start()
    {
        timer = timeAlive;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
