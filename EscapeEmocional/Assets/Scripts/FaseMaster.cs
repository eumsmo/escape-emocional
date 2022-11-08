using UnityEngine;

public class FaseMaster : MonoBehaviour {
    public static int faseId = 0;
    static string[] idName = { "Jogo", "Jogo", "JogoRenata", "JogoRenata" };

    public static string GetFaseName() {
        return idName[faseId];
    }
}
