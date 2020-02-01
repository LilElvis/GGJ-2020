﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell_RandSpawn : MonoBehaviour
{

    //Cell Objects
    public GameObject whiteBloodCell;
    public GameObject redBloodCell;

    [SerializeField]
    private BoxCollider[] collidersObj;
    //private BoxCollider[] boxCol;
    //Variables
    private bool cellSpawnComplete = false;
    public int maxCellOnScreen = 100;
    private int cellsOnScreen = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        collidersObj = gameObject.GetComponentsInChildren<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnCell();
        }

    }

    public void SpawnCell()
    {    
        cellsOnScreen = redCellScript.redCellCount + whiteCellScript.whiteCellCount;
        if (cellsOnScreen < maxCellOnScreen)
        {
            cellSpawnComplete = false;
            while (!cellSpawnComplete)
            {
                int randCol = Random.Range(0, collidersObj.Length);

                Vector3 posWorld = collidersObj[randCol].transform.position + new Vector3(Random.Range(-collidersObj[randCol].size.x / 2, collidersObj[randCol].size.x / 2), Random.Range(-collidersObj[randCol].size.z / 2, collidersObj[randCol].size.z / 2), 0);
                Vector3 posView = Camera.main.WorldToViewportPoint(posWorld);

                if ((posView.x > -0.0f && posView.y < 1.0f) && (posView.y > 0.0f && posView.y < 1.0f))
                {
                    Debug.Log("Cell Spawn Failed: Item in camera space");
                    return;
                }


                //Randomize Type of Cell (White/Red)
                if (Random.Range(0.0f, 1.0f) > 0.2f) //80% Chance
                {
                    Instantiate(redBloodCell, posWorld, Quaternion.identity);
                    Debug.Log("Cell Spawn Complete: Red Cell " + posWorld);
                }
                else //20% Chance
                {
                    Instantiate(whiteBloodCell, posWorld, Quaternion.identity);
                    Debug.Log("Cell Spawn Complete: White Cell" + posWorld);
                }

                
                cellSpawnComplete = true;
                break;
            }
            
        }
        cellsOnScreen = redCellScript.redCellCount + whiteCellScript.whiteCellCount;
        //print("Total cells: " + cellsOnScreen);
    }
}