using UnityEngine;

public class HudAnimationBehaviour : MonoBehaviour
{
    [SerializeField] private string mouseOverAnimation;
    [SerializeField] private string mouseExitAnimation;

    private Animator animator;

    private string currentAnimation;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnMouseOver()
    {
        ChangeAnimationState(mouseOverAnimation);
        Debug.Log("Over");
    }

    public void OnMouseExit()
    {
        ChangeAnimationState(mouseExitAnimation);
        Debug.Log("Exit");
    }

    public void ChangeAnimationState(string animationName)
    {
        //stop the same animation from interrupting itself
        if (currentAnimation == animationName) return;

        //play animation
        animator.Play(animationName);

        //reassign the current state
        currentAnimation = animationName;
    }
}
