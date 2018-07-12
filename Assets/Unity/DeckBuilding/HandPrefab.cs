using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPrefab : MonoBehaviour {
		private const int CARDS_PER_HAND = 5;
		private List<GameObject> cards;
		private bool isFull = false;
		public bool isHandFull(){
			return isFull;
		}

		void Awake()
		{
			cards = new List<GameObject>();
			cards.Capacity = CARDS_PER_HAND;			
		}

		public void addCard(GameObject card){
			if(cards.Count < cards.Capacity){
				this.cards.Add(card);
				card.transform.SetParent(this.transform,false);
				if(cards.Count == cards.Capacity){
					isFull = true;
				}
			}
		}
}
