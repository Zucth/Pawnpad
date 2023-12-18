using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private readonly ArrayList _observers = new ArrayList();

    public void Attach(Observer observer)
    {
        _observers.Add(observer);
    }
    public void Detach(Observer observer) //detach remove
    {
        _observers.Remove(observer);
    }
    public void NotifyObserver() //notifyObserver
    {
        foreach (Observer observer in _observers)
        {
            observer.Notify(this);
        }
    }
}
