using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Game Buttons
    public Button dealBtn; // 딜, 카드를 나누는 버튼(셔플 개념)
    public Button hitBtn; // 히트, 카드 더 뽑아오는 버튼
    public Button standBtn; // 스탠드, 카드를 뽑지 않고 차례 마치기
    public Button betBtn; // 배팅, 칩을 더 건다는 버튼

    private int standClicks = 0;

    // Access the player and dealer's script 
    public PlayerScript playerScript; // 플레이어 스크립트 적용시키기
    public PlayerScript dealerScript; // 딜러 스크립트 적용 시키기

    // public Text to access and update - hud
    public Text scoreText; // 플레이어 점수 스코어 , 21을 생각하고
    public Text dealerScoreText; // 딜러 점수 스코어 ,21을 생각하고
    public Text betsText; // 배팅 거는 숫자 표시, 얼마 걸지
    public Text cashText; // 
    public Text mainText; //
    public Text standBtnText; //

    // Card hiding dealer's 2nd card // 딜러는 2번째 카드 부터 숨긴다 
    public GameObject hideCard;
    // How much is bet
    int pot = 0; //얼마나 걸건지, 기본 배팅단위

    void Start()
    {
        // Add on click listeners to the buttons // 버튼 생성값으로 가져오기(읽기) , get 과 같다.
        dealBtn.onClick.AddListener(() => DealClicked()); // 스크립트에 온클릭 리스너 추가 ,셔플개념
        hitBtn.onClick.AddListener(() => HitClicked()); // 스크립트에 온클릭 리스너 추가 ,카드 가져오기개념
        standBtn.onClick.AddListener(() => StandClicked()); //  스크립트에 온클릭 리스너 추가 ,한턴 쉬기 개념
        betBtn.onClick.AddListener(() => BetClicked()); //  스크립트에 온클릭 리스너 추가 ,배팅 개념
    }

    private void DealClicked() // 딜클릭에 대해서 설명, 온클릭 버튼 누르면 작동되는 함수
    {
        // Reset round, hide text, prep for new hand // 한라운드를 리샛하고 텍스트를 숨기고 새 덱으로 셔플한다.
        playerScript.ResetHand(); // 플레이어 의 핸드를 리셋
        dealerScript.ResetHand(); // 딜러의 핸드를 리셋
        // Hide deal hand score at start of deal
        dealerScoreText.gameObject.SetActive(false);  // 딜러의 점수 스코어를 안보이게 한다.
        mainText.gameObject.SetActive(false); // 게임의 메인 택스트를 안보이게 한다.
        dealerScoreText.gameObject.SetActive(false); // ?? 이건 브레이킹 포인트 찍어서 확인해보야됨
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle(); // 덱이라는 오브젝트 찾은 다음 덱스크립트를 셔플한다.
        playerScript.StartHand(); // 플레이의 핸드를 새로 가져옴
        dealerScript.StartHand(); // 딜러의 핸드를 새로 가져옴
        // Update the scores displayed
        scoreText.text = "Hand: " + playerScript.handValue.ToString(); //
        dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString(); //
        // Place card back on dealer card, hide card
        hideCard.GetComponent<Renderer>().enabled = true;
        // Adjust buttons visibility
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "Stand";
        // Set standard pot size
        pot = 40;
        betsText.text = "Bets: $" + pot.ToString();
        playerScript.AdjustMoney(-20);
        cashText.text = "$" + playerScript.GetMoney().ToString();

    }

    private void HitClicked()
    {
        // Check that there is still room on the table
        if (playerScript.cardIndex <= 10)
        {
            playerScript.GetCard();
            scoreText.text = "Hand: " + playerScript.handValue.ToString();
            if (playerScript.handValue > 20) RoundOver();
        }
    }

    private void StandClicked()
    {
        standClicks++;
        if (standClicks > 1) RoundOver();
        HitDealer();
        standBtnText.text = "Call";
    }

    private void HitDealer()
    {
        while (dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
            if (dealerScript.handValue > 20) RoundOver();
        }
    }

    // Check for winnner and loser, hand is over
    void RoundOver()
    {
        // Booleans (true/false) for bust and blackjack/21
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = dealerScript.handValue == 21;
        // If stand has been clicked less than twice, no 21s or busts, quit function
        if (standClicks < 2 && !playerBust && !dealerBust && !player21 && !dealer21) return;
        bool roundOver = true;
        // All bust, bets returned
        if (playerBust && dealerBust)
        {
            mainText.text = "All Bust: Bets returned";
            playerScript.AdjustMoney(pot / 2);
        }
        // if player busts, dealer didnt, or if dealer has more points, dealer wins
        else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            mainText.text = "Dealer wins!";
        }
        // if dealer busts, player didnt, or player has more points, player wins
        else if (dealerBust || playerScript.handValue > dealerScript.handValue)
        {
            mainText.text = "You win!";
            playerScript.AdjustMoney(pot);
        }
        //Check for tie, return bets
        else if (playerScript.handValue == dealerScript.handValue)
        {
            mainText.text = "Push: Bets returned";
            playerScript.AdjustMoney(pot / 2);
        }
        else
        {
            roundOver = false;
        }
        // Set ui up for next move / hand / turn
        if (roundOver)
        {
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(true);
            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
            cashText.text = "$" + playerScript.GetMoney().ToString();
            standClicks = 0;
        }
    }

    // Add money to pot if bet clicked
    void BetClicked()
    {
        Text newBet = betBtn.GetComponentInChildren(typeof(Text)) as Text;
        int intBet = int.Parse(newBet.text.ToString().Remove(0, 1));
        playerScript.AdjustMoney(-intBet);
        cashText.text = "$" + playerScript.GetMoney().ToString();
        pot += (intBet * 2);
        betsText.text = "Bets: $" + pot.ToString();
    }
}
