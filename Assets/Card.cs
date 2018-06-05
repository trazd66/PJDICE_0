using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {
	
	/*name of the card*/
	private string name;

	/*the description of the card */
	private string description;

	/*identifier of the card
	each card should has their unique identifier.
	 */
	private int _identifier;

	private List<AbilityCallback> _abilityCallbackList;

	/*construct a new card */
	public Card(string name, int identifier){
		this.name = name;
		this._identifier = identifier;
	}

	
}
