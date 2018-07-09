using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck  {
    private List<Card> cards;

    public static  List<Card> getTestingDeck(){
        var testingDeck = new List<Card>();

        for(int j = 0; j < 40;j++){
            ConstructCard card = new ConstructCard();
            card.setName(j.ToString());
            testingDeck.Add(card);

        }

        return testingDeck;
    }
    public List<Card> getCards(){
        return cards;
    }

    public int getNumOfCards(){
        return this.cards.Count;
    }

    public void setCards(List<Card> cards){
        this.cards = cards;
    }
    public Deck(){
        this.cards = new List<Card>();
    }
}
