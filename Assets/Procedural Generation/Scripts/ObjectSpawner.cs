using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    #region variables

    [Tooltip("Max spawn horizontal position One")]
    [SerializeField] private GameObject airSpawnerOne;
    [Tooltip("Min spawn horizontal postion two")]
    [SerializeField] private GameObject airSpawnerTwo;
    [Tooltip("Max spawn horizontal position One")]
    [SerializeField] private GameObject groundSpawnerOne;
    [Tooltip("Min spawn horizontal postion two")]
    [SerializeField] private GameObject groundSpawnerTwo;
    [Tooltip("Objects that hit this collider will despawn")]
    [SerializeField] private GameObject objectDespawner;

    [Tooltip("Max spawn height")]
    [SerializeField] private float maxAirHeight;
    [Tooltip("Min spawn height")]
    [SerializeField] private float minAirHeight;


    [Tooltip("How often an object spawns")]
    [SerializeField] private float groundObjectWaitTime;
    [Tooltip("How often an object spawns")]
    [SerializeField] private float objectWaitTime;
    [Tooltip("How often a dangerous object spawns")]
    [SerializeField] private float dangerObjectWaitTime;
    [Tooltip("How often a coin object spawns")]
    [SerializeField] private float coinObjectWaitTime;
    [Tooltip("Active game time")]
    private float groundObjectTimeTillSpawn;
    private float objectTimeTillSpawn;
    private float dangerObjectTimeTillSpawn;
    private float coinObjectTimeTillSpawn;

    [Tooltip("Array of gameobjects")]
    [SerializeField] private GameObject[] groundObjectToSpawn;
    [Tooltip("Array of gameobjects")]
    [SerializeField] private GameObject[] airObjectToSpawn;
    [Tooltip("Array of gameobjects")]
    [SerializeField] private GameObject[] airDangerObjectToSpawn;
    [Tooltip("Array of gameobjects")]
    [SerializeField] private GameObject[] coinObjectToSpawn;
    


    #endregion


    private void Update()
    {
       SpawnObjects();

       SpawnGroundObjects();

       SpawnDangerObjects();   
        
       SpawnCoinObjects();
    }
    private void SpawnObjects()
    {
        objectTimeTillSpawn += Time.deltaTime;

        if (objectTimeTillSpawn >= objectWaitTime)
        {
            Vector2 objectSpawnPosition = new Vector2(Random.Range(airSpawnerOne.transform.position.x, airSpawnerTwo.transform.position.x), Random.Range(minAirHeight, maxAirHeight));

            Instantiate(airObjectToSpawn[Random.Range(0, airObjectToSpawn.Length)], objectSpawnPosition, Quaternion.identity);

            objectTimeTillSpawn = 0;
        }

    }

    private void SpawnGroundObjects()
    {
        groundObjectTimeTillSpawn += Time.deltaTime;

        if (groundObjectTimeTillSpawn >= groundObjectWaitTime)
        {
            Vector2 objectSpawnPosition = new Vector2(Random.Range(groundSpawnerOne.transform.position.x, groundSpawnerTwo.transform.position.x), groundSpawnerOne.transform.position.y);

            Instantiate(groundObjectToSpawn[Random.Range(0, groundObjectToSpawn.Length)], objectSpawnPosition, Quaternion.identity);

            groundObjectTimeTillSpawn = 0;
        }

    }

    private void SpawnDangerObjects()
    {
        dangerObjectTimeTillSpawn += Time.deltaTime;

        if (dangerObjectTimeTillSpawn >= dangerObjectWaitTime)
        {
            Vector2 objectSpawnPosition = new Vector2(Random.Range(airSpawnerOne.transform.position.x, airSpawnerTwo.transform.position.x), Random.Range(minAirHeight, maxAirHeight));

            Instantiate(airDangerObjectToSpawn[Random.Range(0, airDangerObjectToSpawn.Length)], objectSpawnPosition, Quaternion.identity);

            dangerObjectTimeTillSpawn = 0;
        }

    }

    private void SpawnCoinObjects()
    {
        coinObjectTimeTillSpawn += Time.deltaTime;

        if (coinObjectTimeTillSpawn >= coinObjectWaitTime)
        {
            Vector2 objectSpawnPosition = new Vector2(Random.Range(airSpawnerOne.transform.position.x, airSpawnerTwo.transform.position.x), Random.Range(minAirHeight, maxAirHeight));

            Instantiate(coinObjectToSpawn[Random.Range(0, coinObjectToSpawn.Length)], objectSpawnPosition, Quaternion.identity);

            coinObjectTimeTillSpawn = 0;
        }

    }

}
