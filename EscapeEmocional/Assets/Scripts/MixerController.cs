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
    bool showPanel;

    public void Update()
    {
        if(ButtonPause.pausado == true){
            showPanel = ButtonPause.pausado;
            panel.SetActive(showPanel);
        } if(ButtonPause.pausado == false){
            showPanel = ButtonPause.pausado;
            panel.SetActive(false);
        }

    }

    public void ChangeVolume()
    {
        mixer.SetFloat("FX",sldVolume.value);
    }
   
}
