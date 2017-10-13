﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Mod_DealerHand : Mod_PlayerHand {

	public Sprite cardBack;

	bool reveal;

	protected override void SetupHand(){
		deck = GameObject.Find("Deck").GetComponent<Mod_DeckOfCards>();
		hand = new List<Mod_DeckOfCards.Card>();

		HitMe();

		//Need to make all cards Hidden

		GameObject cardOne = transform.GetChild(0).gameObject;
		cardOne.GetComponentInChildren<Text>().text = "";
		cardOne.GetComponentsInChildren<Image>()[0].sprite = cardBack;
		cardOne.GetComponentsInChildren<Image>()[1].enabled = false;

		reveal = false;

	}
		
//	protected override void ShowValue(){
//
//		if(hand.Count > 1){
//			if(!reveal){
//				handVals = hand[1].GetCardHighValue();
//
//				total.text = "Dealer: " + handVals + " + ???";
//			} else {
//				handVals = GetHandValue();
//
//				total.text = "Dealer: " + handVals;
//
//				BlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>();
//
//				if(handVals > 21){
//					manager.DealerBusted();
//				} else if(!DealStay(handVals)){
//					Invoke("HitMe", 1);
//				} else {
//					BlackJackHand playerHand = GameObject.Find("Player Hand Value").GetComponent<BlackJackHand>();
//
//					if(handVals < playerHand.handVals){
//						manager.PlayerWin();
//					} else {
//						manager.PlayerLose();
//					}
//				}
//			}
//		}
//	}


	public void RevealCard(){
		reveal = true;

		GameObject cardOne = transform.GetChild(0).gameObject;

		cardOne.GetComponentsInChildren<Image>()[0].sprite = null;
		cardOne.GetComponentsInChildren<Image>()[1].enabled = true;

		ShowCard(hand[0], cardOne, 0);

//		ShowValue();
	}


	void Update(){
		for (int i = 0; i < hand.Count; i++) {
			print (hand [i].suit);
		}

		Debug.Log(Mod_GameManager.flopHand.Count);
	}


}
