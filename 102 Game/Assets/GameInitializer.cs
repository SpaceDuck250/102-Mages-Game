using UnityEngine;

public class GameInitializer : MonoBehaviour
{

    public string initialGameLine;

    void Start()
    {
        DialogueManager.instance.PlayLine(initialGameLine);
    }


}
