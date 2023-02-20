using UnityEngine;
using UnityEngine.Events;

public class TriggersBehaviour : MonoBehaviour
{
    [SerializeField] UnityEvent TriggerOn;
    [SerializeField] private PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerMovement.enabled = false;
            TriggerOn.Invoke();
        }
    }
}
    
