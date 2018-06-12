using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnDieObj 
{
	/*name of the card*/
	private string name;

	/*the description of the card */
	private string description;

	/*identifier of the card
	each card should has their unique identifier.
	 */
	private int _identifier;

	private int position;


	public int getPosition(){
		return this.position;
	}

	protected void setPosition(int pos){
		this.position = pos;
	}

	protected void setID(int identifier){
		this._identifier = identifier;
	}
	protected int getID(int identifier){
		return _identifier;
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
