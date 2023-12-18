using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]
public class SliderForSoundOPtion : MonoBehaviour
    
{   
    /*Slider slider
    {
        get { return GetComponent<Slider>(); }
    } */

    public AudioMixer mixer;

    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider SFXSlider;

    const string MEx = "MasterExposer";
    const string ME = "MusicExposer";
    const string SE = "SFXExposer" ;

    private void Awake()
    {
        MasterSlider.onValueChanged.AddListener(UpdateMasterValue);
        MusicSlider.onValueChanged.AddListener(UpdateMusicValue);
        SFXSlider.onValueChanged.AddListener(UpdateSFXValue);
    }
    public void UpdateMasterValue(float value)
    {
        mixer.SetFloat(MEx, Mathf.Log10(value) * 20);
    }
    public void UpdateMusicValue(float value)
    {
        mixer.SetFloat(ME, Mathf.Log10(value)*20);
    }
    public void UpdateSFXValue(float value)
    {
        mixer.SetFloat(SE, Mathf.Log10(value) * 20);
    }
}
