using UnityEngine;

public class DamageParticleScript : MonoBehaviour
{
    public float timeAlive;
    float timer;

    public float moveSpeed;
    public float downSpeed;
    public float upForce;

    Vector3 velocityX;
    Vector3 velocityY = Vector3.zero;


    private void Start()
    {
        timer = timeAlive;
        AddUpForce();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }

      
        AddFallEffect();
    }

    private void AddFallEffect()
    {
        velocityX = Vector3.right * moveSpeed * Time.deltaTime;

        velocityY += Vector3.down * downSpeed * Time.deltaTime;

        transform.position += velocityY + velocityX;
    }

    private void AddUpForce()
    {
        velocityY += Vector3.up * upForce;
    }
}
