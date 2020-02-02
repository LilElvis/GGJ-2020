using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject head;

    void Start()
    {
        
    }

    void Update()
    {
        if(!target.activeInHierarchy)
        {
            head.SetActive(false);
        }

        transform.LookAt(target.transform);
    }
}
