using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoundManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> woundList;
    [SerializeField] private List<GameObject> warningList;


    private float woundBuffer = 20.0f;

    void Start()
    {
        InvokeRepeating("ActivateRandomWound", woundBuffer, woundBuffer);
    }

    void Update()
    {
        if (Wounds.activeWoundCount <= 3)
        {
            woundBuffer = 25.0f;
        }

    }

    void ActivateRandomWound()
    {
        int index = Random.Range(0, woundList.Capacity - 1);

        if (!woundList[index].activeInHierarchy)
        {
            woundList[index].SetActive(true);
            warningList[index].SetActive(true);
        }
        else
            ActivateRandomWound();
    }
}
