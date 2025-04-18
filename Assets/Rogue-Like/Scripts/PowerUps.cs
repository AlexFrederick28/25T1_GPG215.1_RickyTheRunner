using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// This script is used to declare card power ups or all stages
/// </summary>
public class PowerUps : MonoBehaviour
{
    [SerializeField] private CardHandler _CardHandler;
    private ObjectSpawner _ObjectSpawner;

    // All Cards and their info go here
    [Space]
    [Header("Cards")]
    [SerializeField] private Card coin;
    [SerializeField] private GameObject silverBundle;
    [SerializeField] private GameObject goldBundle;
    private bool coinIsSilver = false;
    private bool coinIsGold = false;
    [Space]
    [SerializeField] private Card ghost;
    [HideInInspector]
    public float ghostTime;
    [Space]
    [SerializeField] private Card shrink;
    [HideInInspector]
    public float shrinkTime;
    [HideInInspector]
    public float shrinkSize;
    [Space]
    [SerializeField] private Card shield;
    [HideInInspector]
    public float shieldSize;

    private void Update()
    {
        GetReferences();

        ShrinkPower();

        GhostPower();

        ShieldPower();
        ShieldSize();

        CoinPower();
    }

    public void ShrinkPower()
    {
        
        // SHRINK
        switch (shrink.upgradeLevel)
        {
            case 2: // '2' = bronze 
                shrinkTime = 2;
                shrinkSize = 0.8f;
                break;
            case 3: // '3' = silver
                shrinkTime = 3;
                shrinkSize = 0.6f;
                break;
            case 4: // '4' = Gold
                shrinkTime = 5;
                shrinkSize = 0.4f;
                break;
        }

    }

    public void GhostPower()
    {

        // GHOST
        switch (ghost.upgradeLevel)
        {
            case 2: // '2' = bronze 
                ghostTime = 2;
                break;
            case 3: // '3' = silver
                ghostTime = 3;
                break;
            case 4: // '4' = Gold
                ghostTime = 5;
                break;
        }
    }

    public void ShieldPower()
    {

        // SHIELD
        switch (shield.upgradeLevel)
        {
            case 2: // '2' = bronze 
                shieldSize = 5;
                break;
            case 3: // '3' = silver
                shieldSize = 6;
                break;
            case 4: // '4' = Gold
                shieldSize = 8;
                break;
        }
    }

    public void CoinPower()
    {

        switch (coin.upgradeLevel)
        {
            case 2: // '2' = bronze 
                // use default prefab
                break;
            case 3: // '3' = silver
                coinIsSilver = true;
                break;
            case 4: // '4' = Gold
                coinIsSilver= false;
                coinIsGold = true;
                break;
        }

        if (coinIsSilver == true && !_ObjectSpawner.powerUpToSpawnList.Contains(silverBundle))
        {
            if (_ObjectSpawner.powerUpToSpawnList.Contains(coin.powerUpPrefab))
            {
                _ObjectSpawner.powerUpToSpawnList.Remove(coin.powerUpPrefab);
            }
            else
            {
                _ObjectSpawner.powerUpToSpawnList.Add(silverBundle);
            }  
        }
        else if (coinIsGold == true && !_ObjectSpawner.powerUpToSpawnList.Contains(goldBundle))
        {
            if (_ObjectSpawner.powerUpToSpawnList.Contains(silverBundle))
            {
                _ObjectSpawner.powerUpToSpawnList.Remove(silverBundle);
            }
            else
            {
                _ObjectSpawner.powerUpToSpawnList.Add(goldBundle);
            }
        }
    }

    private void GetReferences()
    {
        if (_CardHandler == null || _ObjectSpawner == null)
        {
            _ObjectSpawner = FindAnyObjectByType<ObjectSpawner>();
            _CardHandler = FindAnyObjectByType<CardHandler>();
        }
    }

    private void ShieldSize()
    {
        if (_ObjectSpawner.powerUpToSpawnList.Contains(shield.powerUpPrefab))
        {
            shield.powerUpPrefab.transform.localScale = new Vector3(shieldSize, shieldSize, 0);
        }
    }

}
