using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : Observer
{

    private bool isComplete;
    [SerializeField] private bool isOptional;
    
    public bool IsComplete { get { return isComplete; } }
    public bool IsOptional { get { return isOptional; } }

    public virtual string Name { get { return "Objective"; } }

    void Start()
    {
        isComplete = false;
    }

    protected void Complete()
    {
        isComplete = true;
        GameManager.Instance.ClearObjective();
    }

}
