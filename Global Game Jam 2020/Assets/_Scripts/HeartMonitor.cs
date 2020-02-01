using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMonitor : MonoBehaviour
{
    private float tValue = 0.5f;
    private bool pulse = false;
    [SerializeField]
    private Transform transform;
    [SerializeField]
    private float currentHealth;
    void Start()
    {
        StartCoroutine(HeartRate());
    }

    void Update()
    {
    }

    IEnumerator HeartRate()
    {
        for (; ; )
        {
            tValue = 0.5f * Mathf.Sin(Time.time * 10.0f) + 0.5f;

            transform.position = Vector3.Lerp(new Vector3(0.0f, 5.0f, 0.0f), new Vector3(0.0f, -5.0f, 0.0f), tValue);

            yield return null;
        }
    }
}
