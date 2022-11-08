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
    public int maxObstacles = 1; // Máximo de obstáculos


    public void ActivateRandomObstacle() {
        DeactivateAllObstacles(); // Desliga todos os obstáculos antes de ligar um aleatoriamente

        // Sempre chama o controlador extra, se houver
        if (extraController != null) {
            extraController.ActivateRandomObstacle();
        }

        if (probabilityToBeCalled < 1f && Random.Range(0f, 1f) > probabilityToBeCalled) {
            return;
        }

        int randomNumber;
        if (maxObstacles > 1) {
            // Escolhe x obstáculos aleatórios
            for (int i = 0; i < maxObstacles; i++) {
                randomNumber = Random.Range(0, obstacles.Length);
                obstacles[randomNumber].SetActive(true);
            }
        } else {
            do {
                randomNumber = Random.Range(0, obstacles.Length);
            } while (canRepeatLastObstacle && randomNumber == lastObstacle);
            lastObstacle = randomNumber;
            obstacles[randomNumber].SetActive(true);
        }
       
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
