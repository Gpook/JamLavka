using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour
{
    public Transform target;
    public float movementSpeed = 3f;
    public float height = 5f;
    public float catchingSpeed = 5f;
    public float catchingDistance = 1f;
    private bool isCatching = false;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (!isCatching)
        {
            // Плавно двигаемся к цели по осям Z и X
            Vector3 newPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, movementSpeed * Time.deltaTime);
        }

        // Если цель на достаточном расстоянии для словления, начинаем попытку словить цель
        if (Vector3.Distance(transform.position, target.position) <= catchingDistance)
        {
            isCatching = true;
        }

        if (isCatching)
        {
            // Попытка словить цель, двигаясь вниз по оси Y
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, target.position.y, transform.position.z), catchingSpeed * Time.deltaTime);

            // Если цель словлена, останавливаемся
            if (transform.position.y <= target.position.y)
            {
                isCatching = false;
                transform.position = initialPosition;
            }
        }
    }
}