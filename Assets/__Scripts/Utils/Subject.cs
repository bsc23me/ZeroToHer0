using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{

    List<Observer> observers;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        observers = new List<Observer>();
    }

    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }

    protected void NotifyObservers()
    {
        foreach(Observer o in observers)
            o.Notify();
    }
}
