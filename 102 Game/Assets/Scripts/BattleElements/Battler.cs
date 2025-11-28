using UnityEngine;
using System.Collections.Generic;

public class Battler : MonoBehaviour
{
    public List<string> playerAttackLines = new List<string>(); // Meant for player to type in to deal damage
    public List<string> dialogueLines = new List<string>(); // The lines that this battler will say

    public string battlerName;
    public Sprite battlerImage;
    public Sprite fightSceneImage;

    public float[] damageRange = new float[2];
    public HealthScript healthScript;

    public string ChooseRandomLine(List<string> lines)
    {
        int ranValue = Random.Range(0, lines.Count);
        return lines[ranValue];
    }

    public float PickDamageValue()
    {
        float damage = Random.Range(damageRange[0], damageRange[1]);
        return damage;
    }
}
