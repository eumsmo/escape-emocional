using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField] Vector3 rotation;
    public float speedRotation;
    public float speedPingPong;
    public Transform p1;
    public Transform p2;

    float t;

    void FixedUpdate()
    {
        transform.Rotate(rotation * speedRotation * Time.deltaTime);
        t = Mathf.PingPong(Time.time * speedPingPong, 1.0f);
        transform.position = Vector3.Lerp(p1.position, p2.position, t);
    }
}