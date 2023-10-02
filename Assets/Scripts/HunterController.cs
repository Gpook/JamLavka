
using UnityEngine;

public class HunterController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Transform target;
    
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float smoothRotation = 5.0f;
    [SerializeField] private float catchRadius = 1.0f;
    [SerializeField] private float catchSpeed = 2.0f;
    [SerializeField] private float returnSpeed = 2.0f;
    [SerializeField] private float delayBeforeStartFollowing = 2.0f;
    [SerializeField] private float timeProgression;
    [SerializeField] private float speedOffset;

    [SerializeField] private bool isFollowing = false;
    [SerializeField] private bool isCatching = false;

    private void Start()
    {
        initialPosition = transform.position;
        Invoke(nameof(StartFollowing), delayBeforeStartFollowing);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.GameOver();
        }
    }

    private void Update()
    {
        timeProgression += Time.deltaTime / 30;
        if (target == null || !isFollowing) return;
        var targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        var distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        if (!isCatching)
        {
            var targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothRotation * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * (1 + timeProgression) * Time.deltaTime + speedOffset);
            if (distanceToTarget <= catchRadius)
            {
                isCatching = true;
            }
        }
        else
        {
            var catchPosition = new Vector3(target.position.x, target.position.y, target.position.z);
            transform.position = Vector3.MoveTowards(transform.position, catchPosition, catchSpeed * Time.deltaTime);
            if (Physics.CheckSphere(transform.position, catchRadius, LayerMask.GetMask("Target")))
            {
                isFollowing = false;
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
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