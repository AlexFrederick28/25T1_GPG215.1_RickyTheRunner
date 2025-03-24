using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    //public float duration = 5f;
    //public string powerUpType;

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        StartCoroutine(PickUp(other));
    //    }
    //}

    //IEnumerator PickUp(Collider player)
    //{
    //    // Apply effect based on powerUpType
    //    switch (powerUpType)
    //    {
    //        case "Speed":
    //            player.GetComponent<PlayerController>().speed *= 2;
    //            break;
    //        case "Strength":
    //            player.GetComponent<PlayerController>().strength *= 2;
    //            break;
    //    }

    //    // Disable the power-up object
    //    GetComponent<MeshRenderer>().enabled = false;
    //    GetComponent<Collider>().enabled = false;

    //    // Wait for the duration
    //    yield return new WaitForSeconds(duration);

    //    // Reverse the effect
    //    switch (powerUpType)
    //    {
    //        case "Speed":
    //            player.GetComponent<PlayerController>().speed /= 2;
    //            break;
    //        case "Strength":
    //            player.GetComponent<PlayerController>().strength /= 2;
    //            break;
    //    }

    //    // Destroy the power-up object
    //    Destroy(gameObject);
    //}
}
