using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoDetector : MonoBehaviour {
    void OnTriggerEnter(Collider collision) {
        GameObject objeto = collision.gameObject;
        
        if (objeto.tag != "Obstacle")
            return;

        if (GameManager.Instance.isImortal) {
            Destroy(objeto);
            return;
        }
            
        GameManager.Instance.CurrentState = GameManager.GameState.Morreu;
    }
}
