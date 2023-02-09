using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
            gameManager.BackFromInventory();
    }

    public void Back() => gameManager.BackFromInventory();
}
