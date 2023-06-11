using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    private float rotateSpeed = 2056f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
    }
}