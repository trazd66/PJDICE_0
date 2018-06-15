using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Construct : OnDieObj {
		/* The list of callback functions of the card. */
	private bool isBuilt;
	
	private int turnsWaiting;

	public bool isConstructBUilt(){
		return isBuilt;
	}

	public void setBuiltStatus(bool status){
		isBuilt = status;
	}

	public void setTurnsWaiting(int turns){
		turnsWaiting = turns;
	}

	public int getTurnsWaiting(){
		return turnsWaiting;
	}
}
