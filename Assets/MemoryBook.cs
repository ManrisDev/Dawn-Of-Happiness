using DialogueEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MemoryBook : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private Button[] levelButton;


    //private int lastLevelIndex;
    private int levelComplete;


    private void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");

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
            case 4:
                levelButton[0].interactable = true;
                levelButton[1].interactable = true;
                break;
            case 7:
                levelButton[0].interactable = true;
                levelButton[1].interactable = true;
                levelButton[2].interactable = true;
                break;
            case 8:
                levelButton[0].interactable = true;
                levelButton[1].interactable = true;
                levelButton[2].interactable = true;
                levelButton[3].interactable = true;
                break;
            default:
                break;
        }
    }

    public void LoadTo(string name) => SceneManager.LoadScene(name);

    public void Open()
    {
        hud.SetActive(false);
        gameObject.SetActive(true);
        playerMovement.enabled = false;
    }

    public void Close()
    {
        hud.SetActive(true);
        gameObject.SetActive(false);
        playerMovement.enabled = true;
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