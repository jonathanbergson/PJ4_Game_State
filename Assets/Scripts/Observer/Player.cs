using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SubjectPlayer.instance.NotifyObserver();
        }
    }
}
