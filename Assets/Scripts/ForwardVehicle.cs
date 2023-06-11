using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ForwardVehicle : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}