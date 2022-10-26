using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    // Value of card, 2 of clubs = 2, etc
    public int value = 0;

    public int GetValueOfCard() // 카드값 가져오기
    {
        return value;
    }

    public void SetValue(int newValue) //카드값 설정하기
    {
        value = newValue;
    }

    public string GetSpriteName() //해당 카드 이름 가져오기 -> 수로 변경위해서
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }

    public void SetSprite(Sprite newSprite) //해당 카드 이름 설정하기 -> 수로 변경위해서
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void ResetCard() // 카드 값 리셋시키기
    {
        Sprite back = GameObject.Find("Deck").GetComponent<DeckScript>().GetCardBack();// 덱 오브젝트에서 덱 스크립트 찾아오기
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;
    }
}
