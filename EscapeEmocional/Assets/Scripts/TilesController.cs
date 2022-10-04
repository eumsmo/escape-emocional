using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesController : MonoBehaviour
{
    public Transform startPoint; // GameObject marcando o início do tile
    public Transform endPoint; // GameObject marcando o final do tile
    public GameObject[] obstacles; // Lista de obstáculos,
    public int lastObstacle; // Último obstáculo gerado
    public bool canRepeatLastObstacle = true; // Pode repetir o último obstáculo?

    public TilesController extraController; // Controller auxiliar
    public float probabilityToBeCalled = 1f; // Probabilidade de ser chamado


    public void ActivateRandomObstacle() {
        DeactivateAllObstacles(); // Desliga todos os obstáculos antes de ligar um aleatoriamente

        if (probabilityToBeCalled < 1f && Random.Range(0f, 1f) > probabilityToBeCalled) {
            return;
        }


        int randomNumber;
        do {
            randomNumber = Random.Range(0, obstacles.Length);
        } while (canRepeatLastObstacle && randomNumber == lastObstacle);

        lastObstacle = randomNumber;

        if (extraController != null) {
            extraController.ActivateRandomObstacle();
        }

        obstacles[randomNumber].SetActive(true);
    }

    public void DeactivateAllObstacles() // Desliga todos os obstáculos
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }

        if (extraController != null) {
            extraController.DeactivateAllObstacles();
        }
    }
}
