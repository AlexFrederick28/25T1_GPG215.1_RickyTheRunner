using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public string description;
    public Sprite bronzeArtwork;
    public Sprite silverArtwork;
    public Sprite goldArtwork;
    public bool isBronze;
    public bool isSilver;
    public bool isGold;
    public bool cardUsed;
    public UnityEvent upgradeEvent;

}
