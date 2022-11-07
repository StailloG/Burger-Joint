using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    [SerializeField] private int frameLimit;

    void Start()
    {
        Application.targetFrameRate = frameLimit;
    }
}
