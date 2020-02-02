using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileReadWrite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            WriteFile(10);
        }
    }

    public void WriteFile(float score)
    {
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"Assets\_Resources\Scores.txt", true))
        {
            file.WriteLine(score);
        }
    }

    public string[] ReadFile()
    {
        string[] scores =
            System.IO.File.ReadAllLines((@"Assets\_Resources\Scores.txt"));

        return scores;
    }
}
