using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] UnityEvent Pause;
    [SerializeField] UnityEvent Play;

    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject memoryBookPanel;

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

    public void LoadScene(string name) => SceneManager.LoadScene(name);

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowHud(bool state)
    {
        hudPanel.SetActive(state);
        memoryBookPanel.SetActive(!state);
        FindObjectOfType<PlayerMovement>().enabled = state;
    }
}
