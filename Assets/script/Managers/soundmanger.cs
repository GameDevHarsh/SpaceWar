using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class soundmanger : MonoBehaviour
{
    [SerializeField] private AudioMixer musicmixer;
    [SerializeField] private AudioMixer sfxmixer;
    [SerializeField] private Slider sfxslider;
    [SerializeField] private Slider musicslider;
    void Start()
    {
        musicslider.value = PlayerPrefs.GetFloat("Volume", 0.75f);
        sfxslider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
    public void MusicLevel()
    {
        float sliderValue = musicslider.value;
        musicmixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Volume", sliderValue);
    }
    public void SfxLevel()
    {
        float sliderValue1 = sfxslider.value;
        sfxmixer.SetFloat("SfxVolume", Mathf.Log10(sliderValue1) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue1);
    }

}
