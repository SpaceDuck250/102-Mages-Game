using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerScript player;
    public BattleManager battleManager;
    public WordGiver wordGiver;
    public UIManager uiManager;

    private void Awake()
    {
        instance = this;
    }
}
