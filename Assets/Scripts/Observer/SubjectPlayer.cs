using System.Collections.Generic;
using UnityEngine;

public class SubjectPlayer : MonoBehaviour
{
    public static SubjectPlayer instance;
    public List<IObserver> observers;

    void Awake()
    {
        instance = this;
        observers = new List<IObserver>();
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void NotifyObserver()
    {
        foreach(IObserver observer in observers)
        {
            observer.NotifyObserver();
        }
    }
}
