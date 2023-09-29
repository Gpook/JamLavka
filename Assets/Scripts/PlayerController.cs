using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] private bool isGround;
    [SerializeField] private Rigidbody rb;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        transform.position = direction * speed;
        
        if (isGround && Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * 5f, ForceMode.Impulse);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        isGround = (collision.gameObject.layer == groundLayer);
    }
}
