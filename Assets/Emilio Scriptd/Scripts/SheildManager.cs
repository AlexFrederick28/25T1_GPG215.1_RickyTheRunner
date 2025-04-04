using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SheildManager : MonoBehaviour
{
    public static int sheild = 0;
    public Image[] sheilds;
    public Sprite fullSheild;
    public Sprite emptySheild;
    // Update is called once per frame
    void Update()
    {
     foreach (Image img in sheilds)
        {
            img.sprite = emptySheild;
        }
     for(int i = 0; i < sheild; i++)
        {
         sheilds[i].sprite = fullSheild;    
        }
    }
 
}
