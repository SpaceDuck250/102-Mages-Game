using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public string currentLine;
    public TextMeshProUGUI text;

    public float waitTime;

    public string inputString;

    public static DialogueManager instance;

    private void Awake()
    {
        instance = this;
    }

    

    public IEnumerator SlowType(string line)
    {
        text.text = string.Empty;
        foreach (char c in line.ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void PlayLine(string line)
    {
        currentLine = line;

        StopAllCoroutines();
        StartCoroutine(SlowType(line));
    }

    public void FinishLine()
    {
        if (currentLine == null)
        {
            return;
        }

        StopAllCoroutines();
        text.text = currentLine;
    }
}
