using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public string currentLine;
    public TextMeshProUGUI textbox;

    public float waitTime;

    public static DialogueManager instance;

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
        }
    }

    public void PlayLine(string line)
    {
        if (currentLine == line)
        {
            Debug.Log("Already wrote next before");
            return;
        }


        currentLine = line;

        StopAllCoroutines();
        StartCoroutine(SlowType(line));
    }

    public void FinishLine()
    {
        if (currentLine == "")
        {
            return;
        }

        StopAllCoroutines();
        textbox.text = currentLine;
    }
}
