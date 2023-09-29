using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField]private float spawnPos = 0;
    [SerializeField]private float tileLength = 100;
    [SerializeField]private int startTiles = 4;
    [SerializeField]public GameObject[] roadPrefabs;
    [SerializeField]private List<GameObject> activeTiles;
    
    public void Start()
    {
        for (var i = 0; i < startTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            } 
            SpawnTile(Random.Range(0,roadPrefabs.Length));
        }
    }
    
    public void Update()
    {
        if (player.position.z - 60 > spawnPos - (startTiles * tileLength))
        {
            SpawnTile(Random.Range(0, roadPrefabs.Length));
            DeleteTile();
        }                             
    }
    private void SpawnTile(int tileIndex)
    {
        var nextTile = Instantiate(roadPrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
