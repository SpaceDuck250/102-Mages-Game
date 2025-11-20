using TMPro;
using UnityEngine;

public class DamageParticleGenerator : MonoBehaviour
{
    public GameObject damageParticle;
    public Transform damageParticleContainer;

    public Transform enemy;
    public Transform player;

    public float particleSpawnRadius;

    BattleManager battleManager;

    private void Start()
    {
        battleManager = GameManager.instance.battleManager;

        battleManager.onBattleStart += OnBattleStart;
        battleManager.onPlayerAttack += OnPlayerAttack;
    }

    private void OnDestroy()
    {
        battleManager.onPlayerAttack -= OnPlayerAttack;
        battleManager.onBattleStart -= OnBattleStart;


    }

    private void OnBattleStart(Battler obj)
    {
        DestroyAllParticles();
    }

    private void OnPlayerAttack(float damage, Battler currentBattler)
    {
        int roundedDamage = Mathf.RoundToInt(damage);
        SpawnDamageParticle(roundedDamage, enemy.position);
    }

    private void SpawnDamageParticle(float damage, Vector3 generalSpawnPos)
    {

        Vector3 spawnPos = GenerateRandomPositionAroundPoint(generalSpawnPos, particleSpawnRadius);

        GameObject newDamageParticle = Instantiate(damageParticle, spawnPos, Quaternion.identity, damageParticleContainer);

        TextMeshProUGUI newDamageParticleText = newDamageParticle.GetComponent<TextMeshProUGUI>();
        newDamageParticleText.text = damage.ToString();

        newDamageParticle.SetActive(true);


    }

    private Vector3 GenerateRandomPositionAroundPoint(Vector3 originPoint, float radius)
    {
        Vector3 randomPointAround = (Random.insideUnitCircle * radius) + (Vector2)originPoint;
        return randomPointAround;
    }

    private void DestroyAllParticles()
    {
        foreach (Transform child in damageParticleContainer)
        {
            Destroy(child.gameObject);
        }
    }

}
