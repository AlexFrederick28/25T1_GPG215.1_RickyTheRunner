using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour
{
    #region UpgradeUI

    public List<Card> cards;

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
    private bool resetCards = false;
    private bool upgradedCard = false;

    [SerializeField] private ObjectSpawner _ObjectSpawner;

    #endregion

    private void Start()
    {
        if (resetCards == false)
        {
            foreach (var card in cards) // resetting cards to their default values
            {
                card.isBronze = true;
                card.isSilver = false;
                card.isGold = false;
                card.cardUsed = false;
                card.upgradeLevel = 1;
                card.addedPowerUpToSpawn = false;
            }

            resetCards = true;
        }
    }

    public void Update()
    {
        GetReferences();
        SelectPowerUp();
    }

    public void DrawRandomCards()
    {
        pressedUpgradeButton = false;
        upgradedCard = false; // ensures that cards do not upgrade more than once on a single button press

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
            else if (card.isSilver) // custom card logic here
            {
                cardImage[0].sprite = card.silverArtwork;
            }
            else if (card.isGold) // custom card logic here
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
            else if (card.isSilver) // custom card logic here
            {
                cardImage[1].sprite = card.silverArtwork;
            }
            else if (card.isGold) // custom card logic here
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
            else if (card.isSilver) // custom card logic here
            {
                cardImage[2].sprite = card.silverArtwork;
            }
            else if (card.isGold) // custom card logic here
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
            _PlayerLevelHandler.levelUp = false; // finish level up sequence
            _PlayerLevelHandler.pauseGame.Invoke();
            _PlayerLevelHandler.activateOnce = false; // prevents function from looping (protective lock)

            if (leftCard.addedPowerUpToSpawn == false)
            {
                _ObjectSpawner.powerUpToSpawnList.Add(leftCard.powerUpPrefab);

                leftCard.addedPowerUpToSpawn = true;
            }

            if (upgradedCard == false) // ensures that cards do not upgrade more than once on a single button press
            {
                switch (leftCard.upgradeLevel)
                {
                    // card default is bronze
                    case 1: // card is silver
                        leftCard.upgradeLevel = 2;
                        leftCard.isBronze = false;
                        leftCard.isSilver = true;
                        leftCard.isGold = false;
                        upgradedCard = true;
                        break;
                    case 2: // card is gold
                        leftCard.upgradeLevel = 3;
                        leftCard.isBronze = false;
                        leftCard.isSilver = false;
                        leftCard.isGold = true;
                        upgradedCard = true;
                        break;
                    case 3: // card discarded from list
                        leftCard.cardUsed = true;
                        cards.Remove(leftCard);
                        break;

                }
            }
            pressedUpgradeButton = true;
        }
       

    }
    private void MiddleButtonPowerUp()
    {

        if (pressedUpgradeButton == false)
        {
            middleCard.upgradeEvent.Invoke();
            _PlayerLevelHandler.levelUp = false; // finish level up sequence
            _PlayerLevelHandler.pauseGame.Invoke();
            _PlayerLevelHandler.activateOnce = false; // prevents function from looping (protective lock)

            if (middleCard.addedPowerUpToSpawn == false)
            {
                _ObjectSpawner.powerUpToSpawnList.Add(middleCard.powerUpPrefab);

                middleCard.addedPowerUpToSpawn = true;
            }

            if (upgradedCard == false) // ensures that cards do not upgrade more than once on a single button press
            {
                switch (middleCard.upgradeLevel)
                {
                    case 1:
                        middleCard.upgradeLevel = 2;
                        middleCard.isBronze = false;
                        middleCard.isSilver = true;
                        middleCard.isGold = false;
                        upgradedCard = true;
                        break;
                    case 2:
                        middleCard.upgradeLevel = 3;
                        middleCard.isBronze = false;
                        middleCard.isSilver = false;
                        middleCard.isGold = true;
                        upgradedCard = true;
                        break;
                    case 3:
                        middleCard.cardUsed = true;
                        cards.Remove(middleCard);
                        break;
                }
            }
            pressedUpgradeButton = true;
        }

    }
    private void RightButtonPowerUp()
    {

        if (pressedUpgradeButton == false)
        {
            rightCard.upgradeEvent.Invoke();
            _PlayerLevelHandler.levelUp = false; // finish level up sequence
            _PlayerLevelHandler.pauseGame.Invoke();
            _PlayerLevelHandler.activateOnce = false; // prevents function from looping (protective lock)

            if (rightCard.addedPowerUpToSpawn == false)
            {
                _ObjectSpawner.powerUpToSpawnList.Add(rightCard.powerUpPrefab);

                rightCard.addedPowerUpToSpawn = true;
            }

            if (upgradedCard == false) // ensures that cards do not upgrade more than once on a single button press
            {
                switch (rightCard.upgradeLevel)
                {
                    case 1:
                        rightCard.upgradeLevel = 2;
                        rightCard.isBronze = false;
                        rightCard.isSilver = true;
                        rightCard.isGold = false;
                        upgradedCard = true;
                        break;
                    case 2:
                        rightCard.upgradeLevel = 3;
                        rightCard.isBronze = false;
                        rightCard.isSilver = false;
                        rightCard.isGold = true;
                        upgradedCard = true;
                        break;
                    case 3:
                        rightCard.cardUsed = true;
                        cards.Remove(rightCard);
                        break;
                }
            }
            pressedUpgradeButton = true;
        }

    }

    private void GetReferences()
    {
        if (_PowerUps == null)
        {
            _ObjectSpawner = FindAnyObjectByType<ObjectSpawner>();
            _PlayerLevelHandler = FindAnyObjectByType<PlayerLevelHandler>();
            _PowerUps = FindAnyObjectByType<PowerUps>();
        }
    }
}
