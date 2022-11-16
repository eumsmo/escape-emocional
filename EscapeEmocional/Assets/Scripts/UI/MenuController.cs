using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    public GameObject escolhaFases, menu;
    public GameObject[] selecoesFases;
    public GameObject[] personagensFundo;

    void Start() {
        AtualizaUI();
    }

    public void MostraEscolhas() {
        escolhaFases.SetActive(true);
        menu.SetActive(false);
    }

    public void MostraMenu() {
        escolhaFases.SetActive(false);
        menu.SetActive(true);
    }

    public void SelecionaFaseAnterior() {
        FaseMaster.faseId--;
        AtualizaUI();
    }

    public void SelecionaProximaFase() {
        FaseMaster.faseId++;
        AtualizaUI();
    }

    void AtualizaUI() {
        for (int i = 0; i < selecoesFases.Length; i++) {
            selecoesFases[i].SetActive(false);
            personagensFundo[i].SetActive(false);
        }
        selecoesFases[FaseMaster.faseId].SetActive(true);
        personagensFundo[FaseMaster.faseId].SetActive(true);
    }
}
