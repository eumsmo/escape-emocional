using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestosController {
    public Touch theTouch;
    public Vector2 touchEndPosition, touchStartPosition;
    public string movimento = "";

    public bool ChecaGestos() {
        if (Input.touchCount > 0) {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began) {
                touchStartPosition = theTouch.position;
                movimento = "";
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
}
