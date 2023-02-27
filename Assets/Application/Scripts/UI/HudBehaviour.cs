using UnityEngine;

public class HudBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private string mouseOverAnimation;
    [SerializeField] private string mouseExitAnimation;

    [SerializeField] private Animator hudAnimator;

    private string currentAnimation;

    public void Highlighted() => ChangeAnimationState(mouseOverAnimation);

    public void Normal() => ChangeAnimationState(mouseExitAnimation);

    public void ChangeAnimationState(string animationName)
    {
        //stop the same animation from interrupting itself
        if (currentAnimation == animationName) return;

        //play animation
        hudAnimator.Play(animationName);

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
        }  
    }
}
