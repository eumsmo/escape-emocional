using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaMusica : MonoBehaviour
{
    public ButtonPause controller;

    void Start()
    {
        controller.SetMusicaGameObject(gameObject);
    }
}
