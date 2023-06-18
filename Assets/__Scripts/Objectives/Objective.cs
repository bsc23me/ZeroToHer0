using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{

    private bool isComplete;
    
    public bool IsComplete { get { return isComplete; } }

    void Start()
    {
        isComplete = false;
    }

    protected void Complete()
    {
        isComplete = true;
    }
}
