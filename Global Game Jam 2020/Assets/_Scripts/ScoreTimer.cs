using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour
{
    public Text timerText;
    private float scoreTime = 0.0f;

    private float seconds;
    private float minutes;

    private bool paused = true;

    void Update()
    {
        if (!paused)
        {
            scoreTime += Time.deltaTime;

            minutes = (int)(scoreTime / 60f);
            seconds = (int)(scoreTime % 60f);

            timerText.text = minutes.ToString("0") + " : " + seconds.ToString("00");
        }
    }

    //Event Listner---------------------------------------------------------------------------------
    public List<EventRelay.EventMessageType> eventsHandled = new List<EventRelay.EventMessageType>();

    void OnEnable()
    {
        EventRelay.OnEventAction += HandleEvent;
    }

    void OnDisable()
    {
        EventRelay.OnEventAction -= HandleEvent;
    }

    string HandleEvent(EventRelay.EventMessageType messageType, MonoBehaviour sender)
    {
        if (messageType == EventRelay.EventMessageType.GameStart)
        {
            paused = false;
        }
        if (messageType == EventRelay.EventMessageType.GameOver)
        {
            paused = true;

            //TODO, if it's a high score, write the score to the file
        }

        if (eventsHandled.Contains(messageType))
        {
            Debug.Log(this.name + " handled event: " + messageType + " from sender: " + sender);
            return this.ToString();
        }
        else
        {
            return this.ToString();
        }
    }
    //------------------------------------------------------------------------------------------------
}
