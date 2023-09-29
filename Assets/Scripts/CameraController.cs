using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject mCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private int distanceToPlayer;

    private void Update()
    {
        var cameraPosition = mCamera.transform.position;
        cameraPosition.z = player.transform.position.z + distanceToPlayer;
        mCamera.transform.position = cameraPosition;
    }
}
