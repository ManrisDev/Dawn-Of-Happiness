using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI field;
    private int score = 0;

    private void Awake()
    {
        field = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        field.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score += 1;
        field.text = score.ToString();
    }
}
