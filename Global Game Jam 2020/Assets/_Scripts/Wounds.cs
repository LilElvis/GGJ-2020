using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wounds : MonoBehaviour
{
    public static int activeWoundCount = 0;

    private int redCellRequirement = 1;
    private int whiteCellRequirement = 1;

    [SerializeField] private GameObject wound;

    private void Update()
    {
        //print(redCellRequirement);
        //print(whiteCellRequirement);

        if (redCellRequirement < 1 && whiteCellRequirement < 1)
        {
            wound.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedCell") && redCellRequirement > 0)
        {
            print("Red Cell Collision");
            --redCellRequirement;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("WhiteCell") && whiteCellRequirement > 0)
        {
            print("White Cell Collision");
            --whiteCellRequirement;
            Destroy(other.gameObject);
        }
    }

    private void OnEnable()
    {
        activeWoundCount++;

        redCellRequirement = Random.Range(1, 12);

        whiteCellRequirement = Random.Range(1, 4);
    }

    private void OnDisable()
    {
        activeWoundCount--;
    }
}
