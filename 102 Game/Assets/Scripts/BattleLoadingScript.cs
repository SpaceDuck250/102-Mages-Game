using UnityEngine;

public class BattleLoadingScript : MonoBehaviour
{
    BattleManager battleManager;

    public GameObject loadingPanel;

    private void Start()
    {
        battleManager = GameManager.instance.battleManager;
        battleManager.onBattleStart += ShowLoadingScreen;
    }

    private void ShowLoadingScreen(Battler obj)
    {
        loadingPanel.SetActive(true);

        float loadTime = 4.3f;
        Invoke("CloseLoadingPanel", loadTime);
    }

    private void CloseLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }
}
