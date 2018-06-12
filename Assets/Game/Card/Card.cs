using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card :OnDieObj{

	/* The list of callback functions of the card. */

	private List<AbilityCallback> _abilityCallbackList;

	private RequirementCallback _requirement;

	private bool cardPlayable;

	/*construct a new card */
	public Card(string name, int identifier){
		setName(name);
		setID(identifier);
	}

	private void setPlayable(){
		this.cardPlayable = _requirement.getReqFullfilled();
	}

	public bool getPlayable(){
		return cardPlayable;
	}

	public void addAbility(AbilityCallback cb){
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
