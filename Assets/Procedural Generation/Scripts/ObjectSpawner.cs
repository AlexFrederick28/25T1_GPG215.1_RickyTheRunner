using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    #region variables

    [Header("Spawner and Despawner Objects")]
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

    [Space]
    [Header("Air object Spawn Heights")]
    [Tooltip("Max spawn height")]
    [SerializeField] private float maxAirHeight;
    [Tooltip("Min spawn height")]
    [SerializeField] private float minAirHeight;

    [Space]
    [Header("Spawn Times")]
    [Tooltip("How often an object spawns")]
    [SerializeField] private float groundObjectWaitTime;
    [Tooltip("How often an object spawns")]
    [SerializeField] private float objectWaitTime;
    [Tooltip("How often a dangerous object spawns")]
    [SerializeField] private float dangerObjectWaitTime;
    [Tooltip("How often a coin object spawns")]
    [SerializeField] private float coinObjectWaitTime;
    [Tooltip("How often a coin object spawns")]
    [SerializeField] private float largeGroundObjectWaitTime;
    [Tooltip("How often a power up spawns")]
    [SerializeField] private float powerUpWaitTime;

    private float groundObjectTimeTillSpawn;
    private float objectTimeTillSpawn;
    private float dangerObjectTimeTillSpawn;
    private float coinObjectTimeTillSpawn;
    private float largeGroundObjectTimeTillSpawn;
    private float powerUpTimeTillSpawn;

    [Space]
    [Header("All Objects")]
    [Tooltip("List of gameobjects")]
    [SerializeField] private List<GameObject> groundObjectSpawnList;
    [Tooltip("List of gameobjects")]
    [SerializeField] private List<GameObject> airObjectSpawnList;
    [Tooltip("List of gameobjects")]
    [SerializeField] private List<GameObject> airDangerObjectSpawnList;
    [Tooltip("List of gameobjects")]
    [SerializeField] private  List<GameObject> coinObjectSpawnList;
    [Tooltip("List of gameobjects")]
    [SerializeField] private List<GameObject> largeGroundSpawnList;

    [Space]
    [Header("Objects To Spawn")]
    [Tooltip("This list should be empty in inspector before first level up")]
    public List<GameObject> groundObjectToSpawn;
    [Tooltip("This list should be empty in inspector before first level up")]
    public List<GameObject> airDangerObjectToSpawn;
    [Tooltip("This list should be empty in inspector before first level up")]
    public List<GameObject> coinObjectToSpawn;
    [Tooltip("This list should be empty in inspector before first level up")]
    public List<GameObject> largeGroundObjectToSpawn;
    public List<GameObject> powerUpToSpawnList;

    [Space]
    [SerializeField] private PowerUps _PowerUps;
    [SerializeField] private PlayerLevelHandler _PlayerLevelHandler;

    #endregion

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        SpawnObjects();

        SpawnGroundObjects();

        SpawnDangerObjects();   
        
        SpawnCoinObjects();

        SpawnLargeGroundObjects();

        SpawnPowerUps();
    }
    private void SpawnObjects()
    {
        objectTimeTillSpawn += Time.deltaTime;

        if (objectTimeTillSpawn >= objectWaitTime)
        {
            Vector2 objectSpawnPosition = new Vector2(Random.Range(airSpawnerOne.transform.position.x, airSpawnerTwo.transform.position.x), Random.Range(minAirHeight, maxAirHeight));

            Instantiate(airObjectSpawnList[Random.Range(0, airObjectSpawnList.Count)], objectSpawnPosition, Quaternion.identity);

            objectTimeTillSpawn = 0;
        }

    }

    private void SpawnGroundObjects()
    {
        if (groundObjectToSpawn.Count != 0)
        {
            groundObjectTimeTillSpawn += Time.deltaTime;

            if (groundObjectTimeTillSpawn >= groundObjectWaitTime)
            {
                Vector2 objectSpawnPosition = new Vector2(Random.Range(groundSpawnerOne.transform.position.x, groundSpawnerTwo.transform.position.x), groundSpawnerOne.transform.position.y);

                Instantiate(groundObjectToSpawn[Random.Range(0, groundObjectSpawnList.Count)], objectSpawnPosition, Quaternion.identity);

                groundObjectTimeTillSpawn = 0;
            }
        }
    }
    public void AddGroundObjectToSpawn()
    {
        if (groundObjectSpawnList.Count != 0) // adds new large obstacles based on player level - introducing a new one each time at random
        {
            int newObject = (Random.Range(0, groundObjectSpawnList.Count));
            groundObjectToSpawn.Add(groundObjectSpawnList[newObject]);
            groundObjectSpawnList.Remove(groundObjectSpawnList[newObject]);
        }
    }

    private void SpawnDangerObjects()
    {
        if (airDangerObjectToSpawn.Count != 0)
        {
            dangerObjectTimeTillSpawn += Time.deltaTime;

            if (dangerObjectTimeTillSpawn >= dangerObjectWaitTime)
            {
                Vector2 objectSpawnPosition = new Vector2(Random.Range(airSpawnerOne.transform.position.x, airSpawnerTwo.transform.position.x), Random.Range(minAirHeight, maxAirHeight));

                Instantiate(airDangerObjectToSpawn[Random.Range(0, airDangerObjectSpawnList.Count)], objectSpawnPosition, Quaternion.identity);

                dangerObjectTimeTillSpawn = 0;
            }
        }
    }
    public void AddDangerObjectToSpawn()
    {
        if (airDangerObjectSpawnList.Count != 0) // adds new large obstacles based on player level - introducing a new one each time at random
        {
            int newObject = (Random.Range(0, airDangerObjectSpawnList.Count));
            airDangerObjectToSpawn.Add(airDangerObjectSpawnList[newObject]);
            airDangerObjectSpawnList.Remove(airDangerObjectSpawnList[newObject]);
        }
    }

    private void SpawnCoinObjects()
    {
        if (coinObjectToSpawn.Count != 0)
        {
            coinObjectTimeTillSpawn += Time.deltaTime;

            if (coinObjectTimeTillSpawn >= coinObjectWaitTime)
            {
                Vector2 objectSpawnPosition = new Vector2(Random.Range(airSpawnerOne.transform.position.x, airSpawnerTwo.transform.position.x), Random.Range(minAirHeight, maxAirHeight));

                Instantiate(coinObjectToSpawn[Random.Range(0, coinObjectSpawnList.Count)], objectSpawnPosition, Quaternion.identity);

                coinObjectTimeTillSpawn = 0;
            }
        }
    }
    public void AddCoinToSpawn()
    {
        if (coinObjectSpawnList.Count != 0) // adds new large obstacles based on player level - introducing a new one each time at random
        {
            int newObject = (Random.Range(0, coinObjectSpawnList.Count));
            coinObjectToSpawn.Add(coinObjectSpawnList[newObject]);
            coinObjectSpawnList.Remove(coinObjectSpawnList[newObject]);
        }
    }

    private void SpawnLargeGroundObjects()
    {
        if (largeGroundObjectToSpawn.Count != 0)
        {
            largeGroundObjectTimeTillSpawn += Time.deltaTime;

            if (largeGroundObjectTimeTillSpawn >= largeGroundObjectWaitTime)
            {
                Vector2 objectSpawnPosition = new Vector2(Random.Range(groundSpawnerOne.transform.position.x, groundSpawnerTwo.transform.position.x), groundSpawnerOne.transform.position.y);

                Instantiate(largeGroundObjectToSpawn[Random.Range(0, largeGroundObjectToSpawn.Count)], objectSpawnPosition, Quaternion.identity);

                largeGroundObjectTimeTillSpawn = 0;
            }
        }
        else
        {
            return;
        }
    }
    public void AddLargeObjectToSpawn()
    {
        if (largeGroundSpawnList.Count != 0) // adds new large obstacles based on player level - introducing a new one each time at random
        {
            int newObject = (Random.Range(0, largeGroundSpawnList.Count));
            largeGroundObjectToSpawn.Add(largeGroundSpawnList[newObject]);
            largeGroundSpawnList.Remove(largeGroundSpawnList[newObject]);
        }
    }

    private void SpawnPowerUps()
    {
        if (powerUpToSpawnList.Count > 0)
        {
            powerUpTimeTillSpawn += Time.deltaTime;

            if (powerUpTimeTillSpawn >= powerUpWaitTime)
            {
                Vector2 objectSpawnPosition = new Vector2(Random.Range(airSpawnerOne.transform.position.x, airSpawnerTwo.transform.position.x), Random.Range(minAirHeight, maxAirHeight));

                Instantiate(powerUpToSpawnList[Random.Range(0, powerUpToSpawnList.Count)], objectSpawnPosition, Quaternion.identity);

                powerUpTimeTillSpawn = 0;
            }
        }
        else
        {
            return;
        }
    }

    private void GetReferences()
    {
        if (_PowerUps == null || _PlayerLevelHandler == null)
        {
            _PlayerLevelHandler = FindAnyObjectByType<PlayerLevelHandler>();
            _PowerUps = FindAnyObjectByType<PowerUps>();
        }
    }

}
