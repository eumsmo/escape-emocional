using UnityEngine;
using UnityEngine.SceneManagement;

public class EscolheFase : MonoBehaviour {
    public int faseId = 0;
    public string faseName = "Jogo";

    public void MudaFase() {
        FaseMaster.faseId = faseId;
        SceneManager.LoadScene(faseName);
    }
}
