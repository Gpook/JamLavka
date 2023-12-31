using System.Collections;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int distanceToPlayer;
    [SerializeField] private float spawnInterval = 3f;
    
    [SerializeField] private GameObject[] spawnPos;
    [SerializeField] private GameObject[] spawnObj;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }
    
    private IEnumerator SpawnObject()
    {
        while (true)
        {
            var positionToSpawn = spawnPos[Random.Range(0, spawnPos.Length)];
            var objectToSpawn = spawnObj[Random.Range(0, spawnObj.Length)];
            
            var randomRotationX = Random.Range(0f, 360f);
            var randomRotationY = Random.Range(0f, 360f);
            var randomRotationZ = Random.Range(0f, 360f);
            
            var randomRotation = Quaternion.Euler(randomRotationX, randomRotationY, randomRotationZ);
            
            Instantiate(objectToSpawn, positionToSpawn.transform.position, randomRotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StopSpawnObstacle()
    {
        StopCoroutine(SpawnObject());
    }
    
    private void Update()
    {
        var obstaclePosition = transform.position;
        obstaclePosition.z = player.transform.position.z + distanceToPlayer;
        transform.position = obstaclePosition;
    }
}
