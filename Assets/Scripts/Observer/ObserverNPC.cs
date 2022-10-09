using UnityEngine;

public class ObserverNPC : MonoBehaviour, IObserver
{
    void Start()
    {
        SubjectPlayer.instance.AddObserver(this);
    }

    public void NotifyObserver()
    {
        Debug.Log("Avisando: " + gameObject.name);
    }
}
