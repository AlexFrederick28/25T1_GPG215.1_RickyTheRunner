using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class EvilTree : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float transitionTime;
    [SerializeField] private float timeTillStartAttack;

    [SerializeField] private GameObject idleObject;
    [SerializeField] private GameObject attackObject;
    [SerializeField] private GameObject fistObject;

    [SerializeField] private GameObject positionOne;
    [SerializeField] private GameObject positionTwo;
    [SerializeField] private GameObject positionThree;

    private bool movedToPosOne = false;
    private bool movedToPosTwo = false;
    private bool movedToPosThree = false;

    private void Update()
    {
        StartCoroutine(CMoveFist());
    }

    private IEnumerator CMoveFist()
    {
        yield return new WaitForSeconds(timeTillStartAttack);

        idleObject.SetActive(true);
        attackObject.SetActive(false);

        if (fistObject.transform.position.y > positionTwo.transform.position.y && movedToPosTwo == false)
        {
            Vector3 moveFist = new Vector3(positionTwo.transform.position.x - fistObject.transform.position.x, positionTwo.transform.position.y - fistObject.transform.position.y, 0).normalized;

            fistObject.transform.position += speed * Time.deltaTime * moveFist;
        }
        
        yield return new WaitForSeconds(transitionTime);

        movedToPosTwo = true;

        if (fistObject.transform.position.x > positionThree.transform.position.x && movedToPosThree == false)
        {
            Vector3 moveFist = new Vector3(positionThree.transform.position.x - fistObject.transform.position.x, positionThree.transform.position.y - fistObject.transform.position.y, 0).normalized;

            fistObject.transform.position += speed * Time.deltaTime * moveFist;
        }
        
        yield return new WaitForSeconds(transitionTime);

        movedToPosThree = true;

        if (fistObject.transform.position.y < positionOne.transform.position.y && fistObject.transform.position.x < positionOne.transform.position.x)
        {
            Vector3 moveFist = new Vector3(positionOne.transform.position.x - fistObject.transform.position.x, positionOne.transform.position.y - fistObject.transform.position.y, 0).normalized;

            fistObject.transform.position += speed * Time.deltaTime * moveFist;
        }

        yield break;
    }
}
