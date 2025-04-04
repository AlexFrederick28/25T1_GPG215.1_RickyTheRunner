using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            Add();
        }
        if (collision.CompareTag("Bomb"))
        {
            Remove();
        }
    }
    public void Add()
    {
        SheildManager.sheild++;
    }
    public void Remove()
    {
        SheildManager.sheild--;
    }
    public void goSmall()
    {
     
    }
}
