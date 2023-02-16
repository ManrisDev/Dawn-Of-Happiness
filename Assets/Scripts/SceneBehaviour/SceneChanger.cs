using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    Animator fadeAnimator;

    private void Start() => fadeAnimator = GetComponent<Animator>();

    public void FadeToLevel() => fadeAnimator.SetTrigger("fade");

    public void OnFadeComplete() =>LevelController.instance.isEndGame();
}
