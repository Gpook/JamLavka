using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public Transform target;
    public float moveSpeed = 5.0f;
    public float smoothRotation = 5.0f;
    public float catchRadius = 1.0f;
    public float catchSpeed = 2.0f;
    public float returnSpeed = 2.0f;
    public float delayBeforeStartFollowing = 2.0f;

    private bool isFollowing = false;
    private bool isCatching = false;
    private Vector3 initialPosition;
    [SerializeField] float timeProgression;
    [SerializeField] float speedOffset;

    private void Start()
    {
        initialPosition = transform.position;
        Invoke("StartFollowing", delayBeforeStartFollowing);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController.GameOver();
        }
    }

    private void FixedUpdate()
    {
        timeProgression += Time.deltaTime / 30;
      
        if (target == null || !isFollowing) return;

        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
       
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        if (!isCatching)
        {
            // Smoothly rotate towards the target
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothRotation * Time.deltaTime);

            // Move towards the target in X and Z axes
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * (1 + timeProgression) * Time.deltaTime + speedOffset);

            // If the target stops moving, the hunter should keep approaching
            if (distanceToTarget <= catchRadius)
            {
                isCatching = true;
               
            }
        }
        else
        {
            // Move towards the target in Y axis for catching
            Vector3 catchPosition = new Vector3(target.position.x, target.position.y, target.position.z);
            
            transform.position = Vector3.MoveTowards(transform.position, catchPosition, catchSpeed * Time.deltaTime);

            // Check if hunter's collider is in contact with the target's collider
            if (Physics.CheckSphere(transform.position, catchRadius, LayerMask.GetMask("Target")))
            {
                isFollowing = false;
                playerController.GameOver();
            }
        }
    }

    private void StartFollowing()
    {
        isFollowing = true;
    }

    private void ReturnToRegularPosition()
    {
        isCatching = false;
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);
    }
}