using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGround;


    private void Jump()
    {
        if (isGround)
        {
            
        }
    }

    private void Update()
    {
        player.transform.position = direction * speed;
    }
}
