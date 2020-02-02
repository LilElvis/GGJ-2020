using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*centre = transform.position;

        angle += rotateSpeed * Time.deltaTime;

        Vector3 offset = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = centre + offset;*/
        transform.Rotate(0.0f, 0.0f, 0.3f);
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "RedCell" || other.gameObject.tag == "WhiteCell")
        {
            //Debug.Log("Work!");
            other.gameObject.transform.SetParent(transform);
        }
    }
}
