using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : Observer
{

    private bool isComplete;
    
    public bool IsComplete { get { return isComplete; } }

    public virtual string Name { get { return "Objective"; } }

    void Start()
    {
        isComplete = false;
    }

    protected void Complete()
    {
        isComplete = true;
        GameManager.Instance.ClearObjective(this);
    }

}
