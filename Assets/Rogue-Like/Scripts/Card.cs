using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public string description;
    public Sprite artwork;
    public bool isBronze;
    public bool isSilver;
    public bool isGold;
    public bool cardUsed;

}
