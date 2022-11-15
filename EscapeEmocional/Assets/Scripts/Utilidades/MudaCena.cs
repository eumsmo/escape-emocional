using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCena : MonoBehaviour {
    public string cena = "";

    public void Trocar() {
        SceneManager.LoadScene(cena);        
    }
}
