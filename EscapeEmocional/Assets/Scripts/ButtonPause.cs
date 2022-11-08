using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    public static bool pausado = false;

    void Start()
    {
        pausado = false;
    }


    public void pause()
    {
        Time.timeScale = 0;   
        pausado = true;  
        
    }
    
    public void sairpause()
    {
        Time.timeScale = 1;
        pausado = false;  
    }
}
