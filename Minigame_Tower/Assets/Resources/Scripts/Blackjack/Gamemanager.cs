using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    // 게임 실행 버튼
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betBtn;

    private int standClicks = 0; //클릭 횟수 초기화

    // 플레이어 스크립트랑 딜러 스크립트 넣을 수 있도록 만들어주기
    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    // 텍스트 스크립트들 일일이 넣어주도록 하기
    public Text scoreText;
    public Text dealerScoreText;
    public Text betsText;
    public Text cashText;
    public Text mainText;
    public Text standBtnText;

    //  딜러의 카드 숨기기(두번째부터)
    public GameObject hideCard;
    // 얼마나 배팅할지... 일단 0으로 초기화
    int pot = 0;

    void Start()
    {
        // 버튼들 불러오기
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
        betBtn.onClick.AddListener(() => BetClicked());
    }

    private void DealClicked()
    { 


    }

    private void HitClicked()
    {
        
    }

    private void StandClicked()
    {
       
    }

    // Check for winnner and loser, hand is over
    void RoundOver()
    {
       
    }

    // Add money to pot if bet clicked
    void BetClicked()
    {
      
    }
}
