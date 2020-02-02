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

    public FileReadWrite readWrite;
    private string[] highScores;

    private bool paused = true;

    private void Start()
    {
        highScores = new string[5];
    }

    void Update()
    {
        if (!paused)
        {
            //timerText1.text = minutes.ToString("00") + ":" + seconds.ToString("00");
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
            highScores = readWrite.ReadFile();

            float tempTime;
            int tempMin;
            int tempSec;

            foreach (string aScore in highScores)
            {
                /*for (int i = 0; i < aScore.Length; i++)
                {
                    tempTime = aScore[i];
                }*/
                tempTime = float.Parse(aScore);
                Debug.Log(tempTime);
                if (tempTime > scoreTime)
                {
                    continue;
                }
                else if (tempTime < scoreTime)
                {
                    readWrite.WriteFile(scoreTime);
                }
                //tempMin = (int)(tempTime / 60f);
                //tempSec = (int)(tempTime % 60f);
            }

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
