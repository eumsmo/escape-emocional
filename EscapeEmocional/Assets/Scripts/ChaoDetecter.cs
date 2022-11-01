using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoDetecter : MonoBehaviour
{
    public bool isOnFloor = true;
    public List <GameObject> currentCollisions = new List <GameObject> ();

    void OnTriggerEnter(Collider other)
    {
        GameObject objeto = other.gameObject;
        if (objeto.tag == "Obstacle" || objeto.tag == "Floor")
        {
            isOnFloor = true;
            currentCollisions.Add(objeto);
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject objeto = other.gameObject;
        if (objeto.tag == "Obstacle" || objeto.tag == "Floor")
        {
            currentCollisions.Remove(objeto);

            if (currentCollisions.Count == 0)
                isOnFloor = false;
        }
    }

}
