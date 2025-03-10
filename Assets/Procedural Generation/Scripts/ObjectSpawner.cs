using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    #region variables

    [Tooltip("Max spawn horizontal position One")]
    [SerializeField] private GameObject spawnerOne;
    [Tooltip("Min spawn horizontal postion two")]
    [SerializeField] private GameObject spawnerTwo;
    [Tooltip("Objects that hit this collider will despawn")]
    [SerializeField] private GameObject objectDespawner;

    [Tooltip("Max spawn height")]
    [SerializeField] private float maxHeight;
    [Tooltip("Min spawn height")]
    [SerializeField] private float minHeight;
    [Tooltip("How often an object spawns")]
    [SerializeField] private float waitTime;
    [Tooltip("Active game time")]
    [SerializeField] private float timeTillSpawn;
    
    [Tooltip("Array of gameobjects")]
    [SerializeField] private GameObject[] objectToSpawn;


    #endregion

   
    private void Update()
    {

       SpawnObjects();
        
    }
    private void SpawnObjects()
    {
        timeTillSpawn += Time.deltaTime;

        if (timeTillSpawn >= waitTime)
        {
            Vector2 objectSpawnPosition = new Vector2(Random.Range(spawnerOne.transform.position.x, spawnerTwo.transform.position.x), Random.Range(minHeight, maxHeight));

            Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Length)], objectSpawnPosition, Quaternion.identity);

            timeTillSpawn = 0;
        }

    }


}
