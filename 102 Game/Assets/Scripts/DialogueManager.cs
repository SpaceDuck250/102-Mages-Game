using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class DialogueManager : MonoBehaviour
{
    public string currentLine;
    public TextMeshProUGUI textbox;

    public float waitTime;

    public static DialogueManager instance;

    public event System.Action onType;
    public System.Action onTypeEnd;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.RightShift))
        {
            FinishLine();
        }
    }
    
    public IEnumerator SlowType(string line)
    {
        if (line != null)
        {
            textbox.text = string.Empty;
            foreach (char c in line.ToCharArray())
            {
                textbox.text += c;
                yield return new WaitForSeconds(waitTime);
            }

            onTypeEnd?.Invoke();
        }
    }

    public void PlayLine(string line)
    {
        if (currentLine == line || line == string.Empty)
        {
            Debug.Log("Already wrote next before");
            return;
        }


        currentLine = line;

        StopAllCoroutines();
        StartCoroutine(SlowType(line));

        onType?.Invoke();
    }

    public void FinishLine()
    {
        if (currentLine == "")
        {
            return;
        }

        StopAllCoroutines();
        textbox.text = currentLine;

        onTypeEnd?.Invoke();
    }
}
