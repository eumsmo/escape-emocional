using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sldVolume;
    public Slider sldMusic;

    void Start() {
        sldVolume.value = mixer.GetFloat("FX", out float volume) ? volume : 0;
        sldMusic.value = mixer.GetFloat("Music", out float music) ? music : 0;
    }


    public void ChangeVolume()
    {
        mixer.SetFloat("FX", (sldVolume.value));
    }
    public void ChangeMusic()
    {
        mixer.SetFloat("Music", (sldMusic.value));
    }
}
