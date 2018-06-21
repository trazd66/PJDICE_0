using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Construct : Targetable {
		/* The list of callback functions of the card. */
	private bool constructionComplete;
	
	private int constructionTime;

	public bool isConstructionComplete(){
		return constructionComplete;
	}

	public void setBuiltStatus(bool status){
		constructionComplete = status;
	}

	public void setconstructionTime(int turns){
		constructionTime = turns;
	}

	public int getconstructionTime(){
		return constructionTime;
	}

	public void inConstruction(bool signal){
		if(signal == true && !constructionComplete){
			constructionTime--;
			if(constructionTime == 0){
				constructionComplete = true;
			}
		}
	}

}
