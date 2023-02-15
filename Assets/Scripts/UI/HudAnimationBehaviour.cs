using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class HudAnimationBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private string mouseOverAnimation;
    [SerializeField] private string mouseExitAnimation;

    private Animator animator;

    private string currentAnimation;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnMouseOver() => ChangeAnimationState(mouseOverAnimation);

    public void OnMouseExit() => ChangeAnimationState(mouseExitAnimation);

    public void ChangeAnimationState(string animationName)
    {
        //stop the same animation from interrupting itself
        if (currentAnimation == animationName) return;

        //play animation
        animator.Play(animationName);

        //reassign the current state
        currentAnimation = animationName;
    }

    public void Click()
    {
        panel.SetActive(!panel.activeSelf);
        if (panel.activeSelf && panel.name.Equals("Inventory"))
        {
            FindObjectOfType<Inventory>().UpdateInventory();
        }
    }
}
