using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApenasUmFilho : MonoBehaviour {
    void Start() {
        // Desativa todos os filhos
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }

        // Gera um número aleatório entre 0 e o número de filhos
        int random = Random.Range(0, transform.childCount);

        // Ativa o filho aleatório
        transform.GetChild(random).gameObject.SetActive(true);
    }
}
