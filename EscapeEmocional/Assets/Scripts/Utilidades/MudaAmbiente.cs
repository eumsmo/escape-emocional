using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaAmbiente : MonoBehaviour {
    public bool fog = false;
    public float fogDensity;
    public Color fogColor;

    public bool changeBackgroundColor = false;
    public Color backgroundColor;
    public bool constantUpdate = false;

    public void UpdateValues() {
        if (fog) {
            RenderSettings.fog = true;
            RenderSettings.fogColor = fogColor;
            RenderSettings.fogDensity = fogDensity;
        }
        else RenderSettings.fog = false;

        if (changeBackgroundColor)
            Camera.main.backgroundColor = backgroundColor;
    }

    void Start() {
        UpdateValues();
    }

    void Update() {
        if (constantUpdate)
            UpdateValues();
    }

    
}
