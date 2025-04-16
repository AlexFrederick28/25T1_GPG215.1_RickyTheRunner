using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// This script is used to declare card power ups or all stages
/// </summary>
public class PowerUps : MonoBehaviour
{
    [SerializeField] private CardHandler _CardHandler;

    // All Cards and their info go here
    [Space]
    [Header("Cards")]
    [SerializeField] private Card coin;
    [Space]
    [SerializeField] private Card ghost;
    [Space]
    [SerializeField] private Card shrink;
    public float shrinkTime;
    public float shrinkSize;
    [Space]
    [SerializeField] private Card shield;

    private void Update()
    {
        GetReferences();

        ShrinkPower();
    }

    public void ShrinkPower()
    {
        
        // SHRINK
        switch (shrink.upgradeLevel)
        {
            case 2: // '2' = bronze 
                shrinkTime = 1;
                shrinkSize = 0.8f;
                Debug.Log("Bronze Shrink size: " + shrinkSize);
                break;
            case 3: // '3' = silver
                shrinkTime = 2;
                shrinkSize = 0.6f;
                Debug.Log("Silver Shrink size: " + shrinkSize);
                break;
            case 4: // '4' = Gold
                shrinkTime = 4;
                shrinkSize = 0.4f;
                Debug.Log("Gold Shrink size: " + shrinkSize);
                break;
        }

    }

    public void GhostPower()
    {
        Debug.Log("Ghost: " + ghost);

        // GHOST
        if (ghost.isSilver)
        {

        }
        else if (ghost.isGold)
        {

        }
    }

    public void ShieldPower()
    {
        Debug.Log("Shield: " + shield);

        // SHIELD
        if (shield.isSilver)
        {

        }
        else if (shield.isGold)
        {

        }
    }

    public void CoinPower()
    {
        Debug.Log("Coin: " + coin);

        if (coin.isSilver)
        {

        }
        else if (coin.isGold)
        {

        }
    }

    private void GetReferences()
    {
        if (_CardHandler == null)
        {
            _CardHandler = FindAnyObjectByType<CardHandler>();
        }
    }

    public void AddPowerLevel(int powerLevel, int powerType)
    {
        powerType = powerLevel;
    }
}
