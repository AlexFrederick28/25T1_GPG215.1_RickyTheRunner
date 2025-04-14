using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour
{
    #region UpgradeUI

    [SerializeField] private List<Card> cards;

    [SerializeField] private TextMeshProUGUI[] cardName;
    [SerializeField] private TextMeshProUGUI[] cardDescription;
    [SerializeField] private Image[] cardImage;

    #endregion



}
