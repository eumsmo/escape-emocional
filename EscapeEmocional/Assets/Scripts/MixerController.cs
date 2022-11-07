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

    public void Update()
    {
        

    }

    public void ChangeVolume()
    {
        mixer.SetFloat("FX",(sldVolume.value * 20 -20 ));
    }
   
}
