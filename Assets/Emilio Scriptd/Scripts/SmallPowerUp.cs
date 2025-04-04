using System.Collections;
using UnityEngine;

public class SmallPowerUp : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(howLong());
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Small"))
        {
            Small();
        }
    }
    public void Small()
    {
       transform.localScale = new Vector2(.7f, .7f);
    }
    IEnumerator howLong()
    {
        yield return new WaitForSeconds(3);
        transform.localScale = new Vector2(1f, 1f);
    }
}
