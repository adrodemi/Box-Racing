using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlane : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(30, 0, 10);
    void Start()
    {

    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}