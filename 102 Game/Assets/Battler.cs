using UnityEngine;
using System.Collections.Generic;

public class Battler : MonoBehaviour
{
    public List<string> attackLines = new List<string>(); // Meant for player to type in to deal damage
    public List<string> dialogueLines = new List<string>(); // The lines that this battler will say

    public float health;

    public float maxHealth;

    public float damage;

    private void Start()
    {
        health = maxHealth;
    }

    public string ChooseRandomLine(List<string> lines)
    {
        int ranValue = Random.Range(0, lines.Count);
        return lines[ranValue];
    }

    public void StartBattle()
    {
        // Deactivate the node analyzer
        // Activate the battle analyzer
    }

    public void FinishBattle()
    {

    }
}
