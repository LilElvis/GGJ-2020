using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell_RandSpawn : MonoBehaviour
{

    //Cell Objects
    public GameObject whiteBloodCell;
    public GameObject redBloodCell;
    private BoxCollider boxCol;

    //Variables
    private bool cellSpawnComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        boxCol = GameObject.FindObjectOfType<BoxCollider>();
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
        cellSpawnComplete = false;
        while (!cellSpawnComplete)
        {
            Vector3 posWorld = this.transform.position + new Vector3(Random.Range(-boxCol.size.x / 2, boxCol.size.x / 2), Random.Range(-boxCol.size.z / 2, boxCol.size.z / 2), 0);
            Vector3 posView = Camera.main.WorldToViewportPoint(posWorld);

            if ((posView.x > -0.0f && posView.y < 1.0f) && (posView.y > 0.0f && posView.y < 1.0f))
            {
                Debug.Log("Cell Spawn Failed: Item in camera space");
                return;
            }

            if (Random.Range(0.0f, 1.0f) > 0.2f)
            {
                Instantiate(redBloodCell, posWorld, Quaternion.identity);
                Debug.Log("Cell Spawn Complete: Red Cell " + posWorld);
            }
            else
            {
                Instantiate(whiteBloodCell, posWorld, Quaternion.identity);
                Debug.Log("Cell Spawn Complete: White Cell" + posWorld);
            }

            cellSpawnComplete = true;
            break;
        }
    }
}