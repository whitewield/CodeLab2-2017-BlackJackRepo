﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DeckOfCards : MonoBehaviour {
	
	public Text cardNumUI;
	public Image cardImageUI;
	public Sprite[] cardSuits;
    
    //inner class. a class inside the deckOfCards script
    //to refer to it, you have to say "DeckOfCards.Card"
    //purely for architecture and logic
	public class Card{

		public enum Suit {
			SPADES, 	//0
            HEARTS,     //1
            DIAMONDS,   //2
            CLUBS       //3
		};

		public enum Type {
			TWO		= 2,
			THREE	= 3,
			FOUR	= 4,
			FIVE	= 5,
			SIX		= 6,
			SEVEN	= 7,
			EIGHT	= 8,
			NINE	= 9,
			TEN		= 10,
			J		= 11,
			Q		= 12,
			K		= 13,
			A		= 14
		};

		public Type cardNum;
		
		public Suit suit;

		public Card(Type cardNum, Suit suit){
			this.cardNum = cardNum;
			this.suit = suit;
		}

		public override string ToString(){
			return "The " + cardNum + " of " + suit;
		}

		public int GetCardHighValue(){
			int val;

			switch(cardNum){
                //change this here so that the A can be 11 or 1
			case Type.A:
				val = 11;
				break;
			case Type.K:
			case Type.Q:
			case Type.J:
				val = 10;
				break;	
			default:
				val = (int)cardNum;
				break;
			}

			return val;
		}
	}

	public static ShuffleBag<Card> deck;

	// Use this for initialization
	void Awake () {

//Game uses 4 decks to make “card counting” difficult.Deck is reused until it contains less than
//20 cards, then reshuffled.

        if (!IsValidDeck()){
			deck = new ShuffleBag<Card>();

			AddCardsToDeck();
		}

        Debug.Log("Cards in Deck: " + deck.Count);
	}

	protected virtual bool IsValidDeck(){
		return deck != null; 
	}

    //the game should be playe with 4 decks,
    //so we run this 4 times.
	protected virtual void AddCardsToDeck(){
        for (int i = 0; i < 4; i++)
        {
            foreach (Card.Suit suit in Card.Suit.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Type type in Card.Type.GetValues(typeof(Card.Type)))
                {
                    deck.Add(new Card(type, suit));
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

	public virtual Card DrawCard(){
		Card nextCard = deck.Next();

		return nextCard;
	}


	public string GetNumberString(Card card){
		if(card.cardNum.GetHashCode() <= 10){
			return card.cardNum.GetHashCode() + "";
		} else {
			return card.cardNum + "";
		}
	}
		
	public Sprite GetSuitSprite(Card card){
		return cardSuits[card.suit.GetHashCode()];
	}
}
