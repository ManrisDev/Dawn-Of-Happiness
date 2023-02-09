using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    [SerializeField] UnityEvent OpenSettings;

    [SerializeField] GameManager gameManager;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.PlayGame();
        }
    }

    public void Continue()
    {
        gameManager.PlayGame();
    }
    public void Settings()
    {
        OpenSettings.Invoke();
    }
    public void Quit()
    {
        gameManager.MainMenu();
    }
}
