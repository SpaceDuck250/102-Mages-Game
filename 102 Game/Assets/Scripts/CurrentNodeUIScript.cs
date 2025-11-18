using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentNodeUIScript : MonoBehaviour
{
    public TMP_InputField inputField;
    public Image currentNodeImageComponent;

    CommandProcessor commandProcessor;

    private void Start()
    {
        commandProcessor = CommandProcessor.instance;
        commandProcessor.onNewNodeEnter += UpdateCurrentNodeImage;
    }

    private void OnDestroy()
    {
        commandProcessor.onNewNodeEnter -= UpdateCurrentNodeImage;
    }


    public void ClearLineWhenEndEnter()
    {
        inputField.text = "";
        inputField.ActivateInputField();
    }

    public void UpdateCurrentNodeImage(NodeScript currentNode)
    {
        Sprite newImage = currentNode.nodeImage;
        currentNodeImageComponent.sprite = newImage;
    }
}
