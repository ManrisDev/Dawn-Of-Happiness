using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] UnityEvent Pause;
    [SerializeField] UnityEvent Play;

    bool pause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
            PauseGame();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlayGame()
    {
        pause = false;
        Time.timeScale = 1;
        Play.Invoke();
    }
    public void PauseGame()
    {
        pause = true;
        Time.timeScale = 0;
        Pause.Invoke();
    }

    public void LoadEnd()
    {
        SceneManager.LoadScene("CatSceneEnd");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
