using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoundManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> woundList = null;
    [SerializeField] private List<GameObject> warningList = null;


    private float woundBuffer = 17.5f;
    private float woundScaleFactor = 0.25f;
    private float minimumWOundBuffer = 10.0f;

    void Start()
    {
        InvokeRepeating("ActivateRandomWound", woundBuffer, woundBuffer);
    }

    void ActivateRandomWound()
    {
        int index = Random.Range(0, woundList.Capacity - 1);

        if (!woundList[index].activeInHierarchy)
        {
            woundList[index].SetActive(true);
            warningList[index].SetActive(true);

            woundBuffer = Mathf.Max((woundBuffer - woundScaleFactor), minimumWOundBuffer);
        }
        else
            ActivateRandomWound();
    }
}
