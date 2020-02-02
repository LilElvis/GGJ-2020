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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timerText1.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        scoreTime += Time.deltaTime;

        minutes = (int)(scoreTime / 60f);
        seconds = (int)(scoreTime % 60f);

        timerText.text = minutes.ToString("0") + ":" + seconds.ToString("00");

    }
}
