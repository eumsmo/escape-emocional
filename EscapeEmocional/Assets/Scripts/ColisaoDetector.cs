using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        GameObject objeto = collision.gameObject;
        if (objeto.tag != "Obstacle")
            return;

        if (GameManager.Instance.isImortal)
            return;
            
        GameManager.Instance.ChangeGameState(GameManager.GameState.Morreu);
        GameManager.Instance.StopGame();
        Debug.Log("Morreu");
    }
}
