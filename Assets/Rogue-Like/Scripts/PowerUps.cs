using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int shrink;
    public int ghost;
    public int shield;
    public int coin;

    public string powerUpName;

    private bool resetLevel = false; 

    [SerializeField] private CardHandler _CardHandler;

    private void Start()
    {
        ResetPowerLevel();

        Debug.Log("Shield: " + shield);
    }

    private void Update()
    {
        GetReferences();
    }

    public void ShrinkPower()
    {
        Debug.Log("Shrink: " + shrink);
    }

    public void GhostPower()
    {
        Debug.Log("Ghost: " + ghost);
    }

    public void ShieldPower()
    {
        Debug.Log("Shield: " + shield);
    }

    public void CoinPower()
    {
        Debug.Log("Coin: " + coin);
    }

    private void GetReferences()
    {
        if (_CardHandler == null)
        {
            _CardHandler = FindAnyObjectByType<CardHandler>();
        }
    }

    private void ResetPowerLevel()
    {
        shrink = 0;
        ghost = 0;
        shield = 0;
        coin = 0;
    }

    public void AddPowerLevel(int powerLevel, int powerType)
    {
        powerType = powerLevel;
    }
}
