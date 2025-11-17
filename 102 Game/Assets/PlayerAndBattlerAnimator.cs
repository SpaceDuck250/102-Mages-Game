using UnityEngine;
using UnityEngine.UI;

public class PlayerAndBattlerAnimator : MonoBehaviour
{
    public Image player;
    public Image battler;

    public Animator playerAnimator;
    public Animator battlerAnimator;

    BattleManager battleManager;


    private void Start()
    {
        battleManager = GameManager.instance.battleManager;

        playerAnimator = player.GetComponent<Animator>();
        battlerAnimator = battler.GetComponent<Animator>();

        battleManager.onPlayerAttack += OnPlayerAttack;
        battleManager.onEnemyAttack += OnBattlerAttack;
    }

    private void OnDestroy()
    {
        battleManager.onPlayerAttack -= OnPlayerAttack;
        battleManager.onEnemyAttack -= OnBattlerAttack;
    }

    private void OnBattlerAttack(float damage, Battler currentBattler)
    {
        PlayAnim(battlerAnimator, "Base Layer.battlerattack");
    }

    private void OnPlayerAttack(float damage, Battler currentBattler)
    {
        PlayAnim(playerAnimator, "Base Layer.playerattack");
    }

    void PlayAnim(Animator animator, string animationName)
    {
        animator.Play(animationName, 0, 0);
    }
}
