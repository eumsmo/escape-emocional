using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeraQueAparece : MonoBehaviour {

    public float probabilityToBeCalled = 1f; // Probabilidade de aparecer

    void Start() {
        if (probabilityToBeCalled < 1f && Random.Range(0f, 1f) > probabilityToBeCalled) {
            return;
        }

        // Se chegou aqui, é porque o objeto não vai aparecer
        gameObject.SetActive(false);
    }

}
