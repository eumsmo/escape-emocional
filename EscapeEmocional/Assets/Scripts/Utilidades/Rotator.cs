using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField] Vector3 rotation;
    public float speedRotation;
    public float speedPingPong;
    
    float t;

    void FixedUpdate()
    {
        transform.Rotate(rotation * speedRotation * Time.deltaTime);
       
    }
}