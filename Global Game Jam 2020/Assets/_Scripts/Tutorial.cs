using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Text TutorialText = null;

    void Update()
    {
        
    }

    public void StartGame()
    {
        string value = EventRelay.RelayEvent(EventRelay.EventMessageType.GameStart, this);
        Debug.Log("GameStart event was seen by: " + value);
    }

    public void PromptOne()
    {
        TutorialText.text = "Collect red and white blood cells.";
    }

    public void PromptTwo()
    {
        TutorialText.text = "Deposit them in wounds to repair your body.";
    }

    public void PromptGo()
    {
        TutorialText.text = "GO!";
    }

    public void WipeText()
    {
        TutorialText.text = " ";
    }
}
