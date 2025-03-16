using System.Collections;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    
    private void Update()
    {
        StartCoroutine(CDestroyGameobject());
    }
    private IEnumerator CDestroyGameobject()
    {
        Vector3 resizeScale = new Vector3(40 + transform.localScale.x, 40 + transform.localScale.y, 0).normalized;
        transform.localScale += 50 * Time.deltaTime * resizeScale;

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }
}
