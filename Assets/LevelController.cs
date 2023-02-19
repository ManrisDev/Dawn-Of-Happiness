using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private float loadDelay;

    public static LevelController instance = null;

    private int sceneIndex;
    private int levelComplete;

    private void Start()
    {
        if (instance == null)
            instance = this;

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");  
    }

    public void isEndGame(int sceneToLoad)
    {
        if (sceneToLoad == -1)
        {
            if (sceneIndex == 8)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
                Invoke("LoadCutSceneEnd", loadDelay);
            }
            else
            {
                if (levelComplete < sceneIndex)
                    PlayerPrefs.SetInt("LevelComplete", sceneIndex);
                Invoke("NextLevel", loadDelay);
            }
        }
        else
            SceneManager.LoadScene(sceneToLoad);
    }

    public void NextLevel() => SceneManager.LoadScene(sceneIndex + 1);

    public void LoadCutSceneEnd() => SceneManager.LoadScene("CutSceneEnd");
}
