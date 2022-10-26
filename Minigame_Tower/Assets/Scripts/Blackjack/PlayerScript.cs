using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // 해당 스크립트는 딜러랑 플레이어 스크립트다

    // 카드스크립트랑 덱 스크립트 불러오기(읽기)
    public CardScript cardScript;
    public DeckScript deckScript;


    public int handValue = 0;


    public int money = 500; // 얼마 베팅할지


    public GameObject[] hand;

    public int cardIndex = 0;

    List<CardScript> aceList = new List<CardScript>();

    public void StartHand()
    {
        GetCard();
        GetCard();
    }


    public int GetCard() //카드읽어오기
    {

        hand[cardIndex].GetComponent<Renderer>().enabled = true;

        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }

        AceCheck();
        cardIndex++;
        return handValue;
    }


    public void AceCheck()
    {

        foreach (CardScript ace in aceList)
        {
            if (handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {

                ace.SetValue(11);
                handValue += 10;
            }
            else if (handValue > 21 && ace.GetValueOfCard() == 11)
            {

                ace.SetValue(1);
                handValue -= 10;
            }
        }
    }


    public void AdjustMoney(int amount)
    {
        money += amount;
    }


    public int GetMoney()
    {
        return money;
    }

    public void ResetHand()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<CardScript>().ResetCard();
            hand[i].GetComponent<Renderer>().enabled = false;
        }
        cardIndex = 0;
        handValue = 0;
        aceList = new List<CardScript>();
    }
}
