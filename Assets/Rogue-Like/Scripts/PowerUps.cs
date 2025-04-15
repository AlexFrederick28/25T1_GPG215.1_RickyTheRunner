using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool shrink = false;
    public bool ghost = false;
    public bool shield = false;
    public bool coin = false;

    public void ShrinkPower()
    {
        Debug.Log("Shrink power active!");
    }

    public void GhostPower()
    {
        Debug.Log("Ghost power active!");
    }

    public void ShieldPower()
    {
        Debug.Log("Shield power active!");
    }

    public void CoinPower()
    {
        Debug.Log("Coin power active!");
    }
}
