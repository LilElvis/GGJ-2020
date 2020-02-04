using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMonitor : MonoBehaviour
{
    private float count = 0.0f;
    private float amplitude = 0.0f;
    private float tValue = 0.5f;
    private float period = 0.0f;
    private Vector3 amplitudeVector;
    [SerializeField] private AudioSource beepSource;
    [SerializeField] private AudioClip beepSound;
    [SerializeField] private AudioClip flatLine;
    [SerializeField] private Transform localTransform;
    [SerializeField] private Transform emitterTransform;
    [Range(0.0f, 100.0f)] static public float currentHealth = 100.0f;
    private bool paused = true;

    void Start()
    {
        period = ((Mathf.PI / 6) + 0.1f);
    }

    void Update()
    {
        if(!paused)
        {

            currentHealth = Mathf.Max(currentHealth - (0.005f * Wounds.activeWoundCount) + 0.002f, 0.0f);
            

           //Debug.Log("Current Health: " + currentHealth);
           // Debug.Log("Rate of Health Loss: " + (lastHealth - currentHealth));
            
        }

        amplitudeVector = new Vector3(0.0f, amplitude, 0.0f);

        tValue = 0.5f * Mathf.Sin(count * -10.0f) + 0.5f;

        emitterTransform.position = Vector3.Lerp(localTransform.position + amplitudeVector, localTransform.position - amplitudeVector, tValue);

        count += Time.deltaTime;

        if (count > Mathf.Max((period + 0.05f), (currentHealth * 0.02f)))
        {
            if(currentHealth >= 1.0f)
            beepSource.PlayOneShot(beepSound);

            //print("Number of active wounds: " + Wounds.activeWoundCount);

            StartCoroutine(HeartBeat());
            count = 0.0f;
        }

        if (currentHealth < 1.0f)
            beepSource.PlayOneShot(flatLine);

        if (currentHealth <= 0.0f)
        {
            //Fire an event to signal a game over
            string value = EventRelay.RelayEvent(EventRelay.EventMessageType.GameOver, this);
            Debug.Log("GameOver event was seen by: " + value);
        }
    }

    IEnumerator HeartBeat()
    {
        amplitude = 5.0f * (currentHealth * 0.01f);

        yield return new WaitForSeconds(period);

        amplitude = 0.0f;
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
