using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public Slider slider;
    public float sliderMusic;
    public AudioMixer audioMixer;
    public void Start()
    {
        sliderMusic = GetComponent<Slider>().value;
        audioMixer.SetFloat("Master", sliderMusic);
    }
    private void volExit()
    {
        audioMixer.GetFloat("Master", out sliderMusic);
    }
}
