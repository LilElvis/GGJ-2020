using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeScale : MonoBehaviour
{
    public RectTransform logoTransform;

    void Update()
    {
        logoTransform.localScale = new Vector3(logoTransform.localScale.x + 0.01f, 2.0f, 2.0f);
    }
}
