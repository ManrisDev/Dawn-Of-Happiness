using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MemoryBook : MonoBehaviour
{
    [SerializeField] private Button[] levelButton;

    //private int lastLevelIndex;
    private int levelComplete;

    private void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        //lastLevelIndex = firstLevelIndex + levelsCount - 1;

        Debug.Log(levelComplete);

        levelButton[0].interactable = false;
        levelButton[1].interactable = false;
        levelButton[2].interactable = false;
        levelButton[3].interactable = false;

        switch (levelComplete)
        {
            case 2:
                levelButton[0].interactable = true;
                break;
            case 3:
                levelButton[0].interactable = true;
                levelButton[1].interactable = true;
                break;
            case 4:
                levelButton[0].interactable = true;
                levelButton[1].interactable = true;
                levelButton[2].interactable = true;
                break;
            case 5:
                levelButton[0].interactable = true;
                levelButton[1].interactable = true;
                levelButton[2].interactable = true;
                levelButton[3].interactable = true;
                break;
            default:
                break;
        }
    }

    public void LoadTo(string name)
    {
        SceneManager.LoadScene(name);
    }

    //Может быть использован в дальнейшем
    public void Reset()
    {
        levelButton[1].interactable = false;
        levelButton[2].interactable = false;
        levelButton[3].interactable = false;

        PlayerPrefs.DeleteAll();
    }
}   