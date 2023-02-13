using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] UnityEvent OpenSettings;

    public void StartGame()
    {
        SceneManager.LoadScene("CatSceneStart");
    }

    public void OpenSettingsPanel()
    {
        OpenSettings.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
