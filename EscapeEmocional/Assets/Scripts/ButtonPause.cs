using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    public static bool pausado = false;

    void Awake()
    {
        SairPause();
    }


    public void Pause()
    {
        Time.timeScale = 0;
        pausado = true;
        Debug.Log("paus");
    }
    
    public void SairPause()
    {
        Time.timeScale = 1;
        pausado = false;  
    }
}
