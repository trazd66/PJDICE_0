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

	/* The list of callback functions of the card. */
	private List<AbilityCallback> _abilityCallbackList;

	/*construct a new card */
	public Card(string name, int identifier){
		setName(name);
		this._identifier = identifier;
	}

	public void setName(string newName) {
		name = newName;
	}

	public string getName() {
		return name;
	}

	public void setDescription(string newDescription) {
		description = newDescription;
	}

	public string getDescription() {
		return description;
	}
}
