using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card :OnDieObj{

	/* The list of callback functions of the public void  */
	private CardType type;
	private Rarity rarity;
	private bool collectible = true;
	private CardSet cardSet;


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

	public  Card(CardDesc desc){
		this.setName(desc.name);
		this.setID(desc.id);
		this.setDescription(desc.description);
		this.type = desc.type;
		this.rarity = desc.rarity;
		this.collectible = desc.collectible;
		this.cardSet = desc.set;
	}

	public void setRarity(Rarity rarity){
		this.rarity = rarity;
	}

	public void setcollectible(bool collectible){
		this.collectible = collectible;
	}
	public void setCardset(CardSet cardSet){
		this.cardSet = cardSet;
	}

	public void setCardType(CardType type){
		this.type = type;
	}

	public Card(){
		this.setName("testing");
	}
}
