using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    public void pause()
    {
        Time.timeScale = 0;
    }
    
    public void sairpause()
    {
        Time.timeScale = 1;
    }
}
