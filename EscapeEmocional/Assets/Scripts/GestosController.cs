using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestosController {
    public Touch theTouch;
    public Vector2 touchEndPosition, touchStartPosition;
    public string movimento = "";
    bool hasHadFirstTouch = false;

    public bool ChecaGestos() {
        if (Input.touchCount == 4 && hasHadFirstTouch) {
            // 4 Toques ativam o cheat de trocar de fase
            FaseMaster.faseId++;
            SceneManager.LoadScene("Jogo");
        } else if (Input.touchCount == 5) {
            // 5 Toques ativam o cheat de ser imortal
            GameManager.Instance.isImortal = true;
        }

        if (Input.touchCount > 0) {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began) {
                touchStartPosition = theTouch.position;
                movimento = "";
                hasHadFirstTouch = true;
            }
            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended) {
                // Define a posição final do toque como sendo a atual
                touchEndPosition = theTouch.position;

                // Se não havia movimento anteriormente
                if (movimento == "") {
                    // Calcula a distância entre a posição inicial e final do toque
                    float x = touchStartPosition.x - touchEndPosition.x;
                    float y = touchStartPosition.y - touchEndPosition.y;

                    // Define o tipo de movimento
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                        movimento = (x > 0) ? "esquerda" : "direita";
                    else if (Mathf.Abs(x) < Mathf.Abs(y))
                        movimento = (y > 0) ? "baixo": "cima";
                    else
                        movimento = "toque";
                    
                    return true;
                }
                
                return false;
            }
        }
        
        return false;
    }

    public bool InputTeclado() {
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up")) {
            movimento = "cima";
        } else if (Input.GetKeyDown("s") || Input.GetKeyDown("down")) {
            movimento = "baixo";
        } else if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) {
            movimento = "esquerda";
        }  else if (Input.GetKeyDown("d") || Input.GetKeyDown("right")) {
            movimento = "direita";
        } else {
            movimento = "";
            return false;
        }
        return true;
    }
}
