using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("AudioSettings")]
    [SerializeField] AudioMixer musicMixer;
    [SerializeField] AudioMixer effectsMixer;

    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider effectVolumeSlider;

    [SerializeField] float musicVolume;
    [SerializeField] float effectVolume;

    [Header("Events")]
    [SerializeField] UnityEvent CloseSettings;

    private void Start()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        effectVolumeSlider.value = PlayerPrefs.GetFloat("effectsVolume");
    }

    private void Update()
    {
        musicMixer.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        effectsMixer.SetFloat("effectsVolume", effectVolume);
        PlayerPrefs.SetFloat("effectsVolume", effectVolume);
    }

    public void SetMusicVolume(float volume)
    {
        if (volume == -40)
            volume = -100;
        musicVolume = volume;
    }
    public void SetEffectsVolume(float volume)
    {
        if (volume == -40)
            volume = -100;
        effectVolume = volume;
    }
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    
    public void ExitSettings()
    {
        CloseSettings.Invoke();
    }
}
