using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public InputField inputField;
    public Text outputText;

    public void OnSubmit()
    {
        string userInput = inputField.name;
        outputText.text = userInput;
    }
}
