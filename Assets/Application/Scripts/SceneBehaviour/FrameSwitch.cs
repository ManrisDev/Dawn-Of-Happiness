using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    [SerializeField] GameObject activeFrame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activeFrame.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activeFrame.SetActive(false);
        }
    }
}
