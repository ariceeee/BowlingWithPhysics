using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    // adding an OnPinFall public event in case any other
    // object needs to know whether pin has fallen (such as gamemanager)
    public UnityEvent OnPinFall = new();
    public bool isPinFallen = false;

    private void OnTriggerEvent(Collider triggeredObject)
    {
        if (triggeredObject.CompareTag("Ground") && !isPinFallen)
        {
            isPinFallen = true;
            OnPinFall?.Invoke();
            Debug.Log($"{gameObject.name} is fallen"); //$ is for string formatting 
        }

    }
}
