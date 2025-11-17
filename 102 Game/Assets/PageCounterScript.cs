using UnityEngine;
using TMPro;

public class PageCounterScript : MonoBehaviour
{
    public TextMeshProUGUI dialoguePageCounter;

    public void CloseDialoguePageCounter()
    {
        dialoguePageCounter.gameObject.SetActive(false);
    }

    public void SetDialoguePageCounter(int currentIndex, int maxIndex)
    {
        dialoguePageCounter.gameObject.SetActive(true);

        int correctedIndex = currentIndex + 1;
        string pageCounterText = $"{correctedIndex} / {maxIndex}";
        dialoguePageCounter.text = pageCounterText;
    }
}
