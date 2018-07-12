using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardPrefab : MonoBehaviour {
	private Card thisCard = null;
	// Use this for initialization
	public Text cardName;
	void Start () {
		if(thisCard == null){
			Debug.Log("CardPrefab with null card field");
			return;
		}
		cardName.text = thisCard.getName();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
	}

	public void setCard(Card card){
		this.thisCard = card;
	}
}
