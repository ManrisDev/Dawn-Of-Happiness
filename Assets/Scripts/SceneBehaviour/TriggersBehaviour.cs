using UnityEngine;
using UnityEngine.Events;

public class TriggersBehaviour : MonoBehaviour
{
    [SerializeField] UnityEvent TriggerOn;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            TriggerOn.Invoke();
        }
    }
}
    
