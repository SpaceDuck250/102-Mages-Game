using UnityEngine;

public class SpecialTextPlayer : MonoBehaviour
{
    BattleManager battleManager;

    private void Start()
    {
        battleManager = GameManager.instance.battleManager;
        battleManager.onPlayerWin += DIsplayWinText;
        battleManager.onPlayerLose += DisplayLoseText;
    }

    private void OnDestroy()
    {
        battleManager.onPlayerWin -= DIsplayWinText;
        battleManager.onPlayerLose -= DisplayLoseText;
    }

    private void DisplayLoseText(Battler currentBattler)
    {
        DialogueManager.instance.PlayLine("You have lost the battle to " + currentBattler.battlerName);
    }

    private void DIsplayWinText(Battler currentBattler)
    {
        DialogueManager.instance.PlayLine("You have won the battle against " + currentBattler.battlerName);
    }


}
