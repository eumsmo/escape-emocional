using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sldVolume;
    public GameObject panel;
    public bool showPanel;

    public void Update()
    {
        showPanel = ButtonPause.pausado;
        panel.SetActive(ButtonPause.pausado);
    }

    public void ChangeVolume()
    {
        mixer.SetFloat("FX",sldVolume.value);
    }
   
}
