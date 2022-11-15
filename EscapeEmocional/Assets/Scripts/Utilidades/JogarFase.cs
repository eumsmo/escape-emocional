using UnityEngine;
using UnityEngine.SceneManagement;

public class JogarFase : MonoBehaviour {
    public void Jogar() {
        SceneManager.LoadScene(FaseMaster.GetFaseName());
    }
}
