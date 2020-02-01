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
    [SerializeField]
    private Transform localTransform;
    [SerializeField]
    private Transform emitterTransform;
    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float currentHealth;

    void Start()
    {
        period = ((Mathf.PI / 6) + 0.1f);
    }

    void Update()
    {
        amplitudeVector = new Vector3(0.0f, amplitude, 0.0f);

        tValue = 0.5f * Mathf.Sin(count * 10.0f) + 0.5f;

        emitterTransform.position = Vector3.Lerp(localTransform.position + amplitudeVector, localTransform.position - amplitudeVector, tValue);

        count += Time.deltaTime;

        if (count > Mathf.Max((period + 0.05f), (currentHealth * 0.02f)))
        {
            StartCoroutine(HeartBeat());
            count = 0.0f;
        }
    }

    IEnumerator HeartBeat()
    { 

        amplitude = 5.0f * (currentHealth * 0.01f);

        yield return new WaitForSeconds(period);

        amplitude = 0.0f;
    }

}
