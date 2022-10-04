using UnityEngine;
using UnityEngine.SceneManagement;

public class EscolheFase : MonoBehaviour {
    public int faseId = 0;

    public void MudaFase() {
        FaseMaster.faseId = faseId;
        SceneManager.LoadScene("Jogo");
    }
}
