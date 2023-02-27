using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightningBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] lights;
    Light2D lightScript;

    [SerializeField] bool turnLight = true;

    private void Awake()
    {
        lightScript= GetComponent<Light2D>();
    }

    private void Update()
    {
        if (lights.Length> 0)
            foreach(GameObject light in lights)
                light.SetActive(turnLight);
        if (turnLight)
            lightScript.intensity = 0.2f;
        else
            lightScript.intensity = 1f;
    }
}
