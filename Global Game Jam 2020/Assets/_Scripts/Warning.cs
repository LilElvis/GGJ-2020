using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] private GameObject target = null;
    [SerializeField] private GameObject head = null;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(target.transform);
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
        if (messageType == EventRelay.EventMessageType.Scabbed)
        {
            if (!target.activeInHierarchy)
            {
                head.SetActive(false);
            }
        }
        if (messageType == EventRelay.EventMessageType.Wounded)
        {
            if (target.activeInHierarchy)
            {
                head.SetActive(true);
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
