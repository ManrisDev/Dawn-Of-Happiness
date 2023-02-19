using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    Animator fadeAnimator;

    [SerializeField] private int sceneToLoad;

    private void Start() => fadeAnimator = GetComponent<Animator>();

    public void FadeToLevel() => fadeAnimator.SetTrigger("fade");

    public void OnFadeComplete() => LevelController.instance.isEndGame(sceneToLoad);
}
