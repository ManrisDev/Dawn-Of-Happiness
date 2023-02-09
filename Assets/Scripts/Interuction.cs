using UnityEngine;
using UnityEngine.Events;

public class Interuction : MonoBehaviour
{
    [SerializeField] UnityEvent Promt;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Promt.Invoke();
        }
    }
}
