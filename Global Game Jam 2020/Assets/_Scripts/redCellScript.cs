﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redCellScript : MonoBehaviour
{
    public static int redCellCount = 0;

    void Awake()
    {
        redCellCount++;
        //print("Red Cells: " + redCellCount);
        //Destroy(gameObject, 5);
    }

    void OnDestroy()
    {
        redCellCount--;
        //print("Red Cells: " + redCellCount);
    }
}
