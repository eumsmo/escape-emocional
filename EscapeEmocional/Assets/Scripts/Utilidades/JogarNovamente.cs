using UnityEngine;
using UnityEngine.SceneManagement;

public class JogarNovamente : MonoBehaviour {
    public void MudaFase() {
        SceneManager.LoadScene(FaseMaster.GetFaseName());
    }
}
