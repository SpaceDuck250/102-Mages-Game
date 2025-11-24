using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerScript player;
    public BattleManager battleManager;
    public WordGiver wordGiver;
    public UIManager uiManager;
    public NodeDialogueSender nodeDialogueSender;
    public DataSaver dataSaver;
    public DataConverter dataConverter;

    private void Awake()
    {
        instance = this;
    }
}
