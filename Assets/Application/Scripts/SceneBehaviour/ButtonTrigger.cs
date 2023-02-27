using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] Animator buttonAnimator;

    string currentState;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            ChangeAnimationState("On");
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            ChangeAnimationState("Off");
        }
    }

    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play animation
        buttonAnimator.Play(newState);

        //reassign the current state
        currentState = newState;
    }
}