using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour
{
    #region UpgradeUI

    [SerializeField] private List<Card> cards;

    [SerializeField] private TextMeshProUGUI[] cardName;
    [SerializeField] private TextMeshProUGUI[] cardDescription;
    [SerializeField] private Image[] cardImage;

    [SerializeField] private Button leftButton;
    [SerializeField] private Button middleButton;
    [SerializeField] private Button rightButton;

    [SerializeField] private Card leftCard;
    [SerializeField] private Card middleCard;
    [SerializeField] private Card rightCard;

    private PowerUps _PowerUps;
    private PlayerLevelHandler _PlayerLevelHandler;

    private bool pressedUpgradeButton = false;
    [SerializeField] private bool resetCards = false;

    #endregion

    public void Update()
    {
        if (resetCards == false)
        {
            foreach (var card in cards) // resetting cards to their default values
            {
                card.isBronze = true;
                card.isSilver = false;
                card.isGold = false;
                card.cardUsed = false;
            }

            resetCards = true;
        }

        GetReferences();
        SelectPowerUp();
    }

    public void DrawRandomCards()
    {
        pressedUpgradeButton = false;

        cardImage[0].sprite = null;
        cardImage[1].sprite = null;
        cardImage[2].sprite = null;

        // STILL NEED (If card was chosen - upgrade)

        if (cardImage[0].sprite == null)
        {
            // Slot One
            int randomCardPicker = Random.Range(0, cards.Count);
            Card card = cards[randomCardPicker]; // picking a random card from the list

            if (card.isBronze) // custom card logic here
            {
                cardImage[0].sprite = card.bronzeArtwork;
            }
            if (card.isSilver) // custom card logic here
            {
                cardImage[0].sprite = card.silverArtwork;
            }
            if (card.isGold) // custom card logic here
            {
                cardImage[0].sprite = card.goldArtwork;
            }

            // set card texts
            cardDescription[0].text = card.description;
            cardName[0].text = card.cardName;

            leftCard = card;

        }
        if (cardImage[1].sprite == null)
        {
            // Slot Two
            int randomCardPicker = Random.Range(0, cards.Count);
            Card card = cards[randomCardPicker]; // picking a random card from the list

            if (card.isBronze) // custom card logic here
            {
                cardImage[1].sprite = card.bronzeArtwork;
            }
            if (card.isSilver) // custom card logic here
            {
                cardImage[1].sprite = card.silverArtwork;
            }
            if (card.isGold) // custom card logic here
            {
                cardImage[1].sprite = card.goldArtwork;
            }

            // card texts
            cardDescription[1].text = card.description;
            cardName[1].text = card.cardName;

            middleCard = card;

        }
        if (cardImage[2].sprite == null)
        {
            // Slot Three
            int randomCardPicker = Random.Range(0, cards.Count);
            Card card = cards[randomCardPicker]; // picking a random card from the list

            if (card.isBronze) // custom card logic here
            {
                cardImage[2].sprite = card.bronzeArtwork;
            }
            if (card.isSilver) // custom card logic here
            {
                cardImage[2].sprite = card.silverArtwork;
            }
            if (card.isGold) // custom card logic here
            {
                cardImage[2].sprite = card.goldArtwork;
            }

            // card texts
            cardDescription[2].text = card.description;
            cardName[2].text = card.cardName;

            rightCard = card;

        }

    }

    private void SelectPowerUp()
    {
        leftButton.onClick.AddListener(LeftButtonPowerUp);
        middleButton.onClick.AddListener(MiddleButtonPowerUp);
        rightButton.onClick.AddListener(RightButtonPowerUp);
    }

    private void LeftButtonPowerUp()
    {

        if (pressedUpgradeButton == false)
        {
            leftCard.upgradeEvent.Invoke();
            _PlayerLevelHandler.levelUp = false;
            _PlayerLevelHandler.pauseGame.Invoke();
            _PlayerLevelHandler.activateOnce = false; // prevents function from looping (protective lock)

            if (leftCard.isBronze)
            {
                // upgrade card
                leftCard.isBronze = false;
                leftCard.isSilver = true;
            }
            else if (leftCard.isSilver)
            {
                // upgrade card
                leftCard.isSilver = false;
                leftCard.isGold = true;
            }
            else if (leftCard.isGold)
            {
                // upgrade card
            }

            Debug.Log("Pressing button");

            pressedUpgradeButton = true;
        }
       

    }
    private void MiddleButtonPowerUp()
    {
        middleCard.upgradeEvent.Invoke();
        _PlayerLevelHandler.levelUp = false;
        _PlayerLevelHandler.pauseGame.Invoke();
        _PlayerLevelHandler.activateOnce = false; // prevents function from looping (protective lock)

        if (middleCard.isBronze)
        {
            // upgrade card
            middleCard.isBronze = false;
            middleCard.isSilver = true; 
        }
        if (middleCard.isSilver)
        {
            // upgrade card
            middleCard.isSilver = false;
            middleCard.isGold = true;
        }
        if (middleCard.isGold)
        {
            // upgrade card
        }
    }
    private void RightButtonPowerUp()
    {
        rightCard.upgradeEvent.Invoke();
        _PlayerLevelHandler.levelUp = false;
        _PlayerLevelHandler.pauseGame.Invoke();
        _PlayerLevelHandler.activateOnce = false; // prevents function from looping (protective lock)

        if (rightCard.isBronze)
        {
            // upgrade card
            rightCard.isBronze = false;
            rightCard.isSilver = true;
        }
        if (rightCard.isSilver)
        {
            // upgrade card
            rightCard.isSilver = false;
            rightCard.isGold = true;
        }
        if (rightCard.isGold)
        {
            // upgrade card
        }
    }

    private void GetReferences()
    {
        if (_PowerUps == null)
        {
            _PlayerLevelHandler = FindAnyObjectByType<PlayerLevelHandler>();
            _PowerUps = FindAnyObjectByType<PowerUps>();
        }
    }
}
