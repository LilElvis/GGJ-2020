using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, 0.3f);
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "RedCell" || other.gameObject.tag == "WhiteCell")
        {
            other.gameObject.transform.SetParent(transform);
        }
    }
}
