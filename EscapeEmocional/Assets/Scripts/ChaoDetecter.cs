using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoDetecter : MonoBehaviour
{
    public bool isOnFloor = true;

    void OnTriggerEnter(Collider other)
    {
        GameObject objeto = other.gameObject;
        if (objeto.tag == "Obstacle" || objeto.tag == "Floor")
            isOnFloor = true;
    }
}
