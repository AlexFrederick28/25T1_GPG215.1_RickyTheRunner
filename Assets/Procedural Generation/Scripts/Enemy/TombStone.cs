using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TombStone : MonoBehaviour
{
    private bool triggered;
    private bool playOnce;
    [SerializeField] private GameObject ghost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<characterController>() && triggered == false)
        {
            triggered = true;
        }

    }
    private void Update()
    {
        if (triggered == true && playOnce == false)
        {
            Vector2 objectSpawnPosition = new Vector2(0, 0);
            Instantiate(ghost, objectSpawnPosition, Quaternion.identity);

            playOnce = true;
        }
    }
}
