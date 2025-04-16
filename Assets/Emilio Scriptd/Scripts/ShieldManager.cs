 using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ShieldManager : MonoBehaviour
{
    public static int shield = 0;
    public Image[] shieldImages;
    public Sprite fullShield;
    public Sprite emptyShield;
    // Update is called once per frame
    void Update()
    {
     foreach (Image img in shieldImages)
        {
            img.sprite = emptyShield;
        }
     for(int i = 0; i < shield; i++)
        {
         shieldImages[i].sprite = fullShield;    
        }
    }
 
}
