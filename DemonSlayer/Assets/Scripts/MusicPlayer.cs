using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicPlayer : MonoBehaviour
{
    public float volume;
    public Slider musicSlider;
    public Slider SFXSlider;
    public AudioSource musicSource;
    public AudioSource effectSource;

    void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat("Music Volume", 1);

        if (musicSlider == null || SFXSlider == null) return;
        musicSlider.value = PlayerPrefs.GetFloat("Music Volume", 1);
        SFXSlider.value = PlayerPrefs.GetFloat("Effect Volume", 1);
    }
    void Update()
    {
        if (musicSlider == null || SFXSlider == null) return;
        musicSource.volume = musicSlider.value;
        if (effectSource == null) return;
        effectSource.volume = SFXSlider.value;
    }
    public void SaveAudio()
    {
        PlayerPrefs.SetFloat("Music Volume", musicSlider.value);
        PlayerPrefs.SetFloat("Effect Volume", SFXSlider.value);
    }
    
}


