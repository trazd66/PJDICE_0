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

	private int position;

	private List<AbilityCallback> _abilityCallbackList;

	private RequirementCallback _requirement;

	private bool cardPlayable;

	/*construct a new card */
	public Card(string name, int identifier){
		this.name = name;
		this._identifier = identifier;
	}

	private void setCardPlayable(){
		this.cardPlayable = _requirement.getReqFullfilled();
	}

	public bool getCardPlayable(){
		return cardPlayable;
	}

	public void addCardAbility(AbilityCallback cb){
		_abilityCallbackList.Add(cb);
	}
	
	public void play(){
		if(cardPlayable){
			//play
			foreach (var cb in _abilityCallbackList){
				cb.call();
			}
		}
	}

	
}
