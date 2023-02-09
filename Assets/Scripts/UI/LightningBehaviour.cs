using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightningBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] lights;
    [SerializeField] Light2D lightScript;

    [SerializeField] bool turnLight = true;

    private void Awake()
    {
        lightScript= GetComponent<Light2D>();
    }

    private void Update()
    {
        if (turnLight)
        {
            foreach(GameObject light in lights)
                light.SetActive(true);
            lightScript.intensity = 0.2f;
        }
        else
        {
            foreach (GameObject light in lights)
                light.SetActive(false);
            lightScript.intensity = 1f;
        }
    }

    public void Turn(bool state)
    {
        turnLight = state;
    }
}
