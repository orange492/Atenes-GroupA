using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public Sprite[] cardSprites; // 카드 53개 이미지 가져오기 배열로...
    int[] cardValues = new int[53]; // 카드 값 생성해주기
    int currentIndex = 0;//초기화 시키기

    void Start()
    {
        GetCardValues(); // 카드값 읽어오기
    }

    void GetCardValues()
    {
        int num = 0;
        // 
        for (int i = 0; i < cardSprites.Length; i++)
        {
            num = i;

            num %= 13; // 총 12의 값으로 나와야되니깐...

            if (num > 10 || num == 0)
            {
                num = 10;
            }
            cardValues[i] = num++;
        }
    }

    public void Shuffle() // 셔플해주기
    {

        for (int i = cardSprites.Length - 1; i > 0; --i)
        {
            int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1;
            Sprite face = cardSprites[i];
            cardSprites[i] = cardSprites[j];
            cardSprites[j] = face;

            int value = cardValues[i];
            cardValues[i] = cardValues[j];
            cardValues[j] = value;
        }
        currentIndex = 1;
    }

    public int DealCard(CardScript cardScript) // 딜러카드 세팅해주기
    {
        cardScript.SetSprite(cardSprites[currentIndex]);
        cardScript.SetValue(cardValues[currentIndex]);
        currentIndex++;
        return cardScript.GetValueOfCard();
    }

    public Sprite GetCardBack()
    {
        return cardSprites[0];
    }
}
