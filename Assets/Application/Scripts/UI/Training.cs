using TMPro;
using UnityEngine;

public class Training : MonoBehaviour
{
    Animator animator;
    private TextMeshProUGUI field;
    [SerializeField] string[] text;

    int currentSentence = 0;
    int step = 1;

    bool[] condition = new bool[4];

    private void Awake()
    {
        field = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        NextSentense();
    }

    void Update()
    {
        condition[0] = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow);
        condition[1] = Input.GetKeyDown(KeyCode.Space);
        condition[2] = Input.GetKeyDown(KeyCode.E);
        condition[3] = Input.GetKeyDown(KeyCode.I);

        if (step < 5)
            if (condition[step - 1])
                {
                    NextSentense();
                    step++;
                }
    }

    public void NextSentense()
    {
        if (currentSentence < text.Length)
            field.text = text[currentSentence];
        currentSentence++;
    }

}
