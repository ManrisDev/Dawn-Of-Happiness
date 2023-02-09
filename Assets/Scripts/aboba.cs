using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aboba : MonoBehaviour
{

    [SerializeField] GameObject[] lights;

    [SerializeField] bool turnLight;

    private void Update()
    {
        foreach (GameObject light in lights)
            light.SetActive(turnLight);
    }

}
