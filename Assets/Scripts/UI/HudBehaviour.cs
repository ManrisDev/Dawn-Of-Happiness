using UnityEngine;

public class HudBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private string mouseOverAnimation;
    [SerializeField] private string mouseExitAnimation;

    private Animator animator;

    private string currentAnimation;

    private void Awake() => animator = GetComponentInChildren<Animator>();

    public void OnMouseEnter() => ChangeAnimationState(mouseOverAnimation);

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

    public void Press()
    {
        panel.SetActive(!panel.activeSelf);
        if (panel.activeSelf)
        { 
            if (panel.name.Equals("Inventory"))
                FindObjectOfType<Inventory>().UpdateInventory();
            else if (panel.name.Equals("MemoryBook"))
                FindObjectOfType<GameManager>().ShowHud(false);
        }  
    }
}
