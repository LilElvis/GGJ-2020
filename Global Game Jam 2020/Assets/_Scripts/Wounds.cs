using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wounds : MonoBehaviour
{
    public static int activeWoundCount = 0;
    private static int redCellCap = 4;
    private static int whiteCellCap = 1;

    private int redCellRequirement = 1;
    private int whiteCellRequirement = 1;

    [SerializeField] private TextMesh whiteText = null;
    [SerializeField] private TextMesh redText = null;

    [SerializeField] private GameObject wound = null;

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

        redText.text = redCellRequirement.ToString();
        whiteText.text = whiteCellRequirement.ToString();
    }

    private void OnEnable()
    {
        activeWoundCount++;
        redCellCap = Mathf.Min(redCellCap + 1, 50);
        whiteCellCap = (redCellCap/4);

        redCellRequirement = Random.Range(Mathf.Max(1, redCellCap - 8), redCellCap);

        whiteCellRequirement = Random.Range(Mathf.Max(1, whiteCellCap - 4), whiteCellCap);

        redText.text = redCellRequirement.ToString();
        whiteText.text = whiteCellRequirement.ToString();

        string value = EventRelay.RelayEvent(EventRelay.EventMessageType.Wounded, this);
        Debug.Log("Wounded event was seen by: " + value);
    }

    private void OnDisable()
    {
        activeWoundCount--;

        string value = EventRelay.RelayEvent(EventRelay.EventMessageType.Scabbed, this);
        Debug.Log("Scabbed event was seen by: " + value);

        HeartMonitor.currentHealth = Mathf.Min(HeartMonitor.currentHealth + 20.0f, 100.0f);
    }
}
