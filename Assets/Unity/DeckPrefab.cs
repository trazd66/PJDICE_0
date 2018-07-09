using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckPrefab : MonoBehaviour {

	private const int CARDS_PER_HAND = 5;
	private const int CARD_HEIGHT = 210;

	private Deck deck;

	private int numOfHands;	
	public GameObject card;
	public GameObject hand;

	private List<GameObject> hands;


	// Use this for initialization
	void Start () {
		//display the cards using the order of the list
		hands = new List<GameObject>();

		deck = new Deck();
		deck.setCards(Deck.getTestingDeck());
		
		numOfHands = deck.getNumOfCards()/CARDS_PER_HAND;
		
		RectTransform rt = this.GetComponent<RectTransform>();
	    
		rt.sizeDelta = new Vector2 (rt.sizeDelta.x, CARD_HEIGHT*numOfHands);

		displayHands();
		displayCards();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void displayHands(){
		for (int i = 0 ; i< numOfHands ; i++){
			GameObject newHand = Instantiate(hand);
			newHand.transform.localScale = new Vector3(1,1,1);
			newHand.transform.SetParent(this.transform,false);
			hands.Add(newHand);
		}
	}

	private void getNextNonFullHand(){
		
	}
	private void displayCards(){
		int i = 0;
		HandPrefab currHand = hands[i].GetComponent<HandPrefab>();
		foreach (var c in deck.getCards()){
			GameObject newCard =  Instantiate(this.card);
			newCard.GetComponent<CardPrefab>().setCard(c);
			if(currHand.isHandFull()){
				i++;
				currHand = hands[i].GetComponent<HandPrefab>();		
			}
			currHand.addCard(newCard);
		}
	}
}
