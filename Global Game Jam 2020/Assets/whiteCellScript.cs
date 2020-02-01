using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteCellScript : MonoBehaviour
{
    public static int whiteCellCount = 0;

    void Awake()
    {
        whiteCellCount++;
        //print("White Cells: " + whiteCellCount);
        Destroy(gameObject, 5);
    }

    void OnDestroy()
    {
        whiteCellCount--;
        //print("White Cells: " + whiteCellCount);
    }
}
