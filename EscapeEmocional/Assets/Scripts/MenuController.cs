using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    public GameObject escolhaFases, jogarBtn;

    public void MostraEscolhas() {
        escolhaFases.SetActive(true);
        jogarBtn.SetActive(false);
    }
}
