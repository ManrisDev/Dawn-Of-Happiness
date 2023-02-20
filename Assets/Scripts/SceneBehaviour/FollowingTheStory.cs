using UnityEngine;
using UnityEngine.Video;

public class FollowingTheStory : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private LevelController levelController;

    private int memoryComplete = 0;

    public void DialogueEnd()
    {
        playerMovement.enabled = true;
    }

    public void SaveMemory()
    {
        switch (memoryComplete)
        {
            case 0:
                memoryComplete++;
                NextScene();
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }

    public void NextScene()
    {
        levelController.isEndGame(-1);
    }
}
