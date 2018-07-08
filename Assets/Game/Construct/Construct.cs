using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A construct on a die. */
public abstract class Construct : Targetable {

	/* True iff the Construct has been built. */
	private bool constructionComplete;
	
	/* The number of turns left before
	 * the Construct is finished being built.
	*/
	private int constructionTime;

	public bool isConstructionComplete() {
		return constructionComplete;
	}

	public void setBuiltStatus(bool status) {
		constructionComplete = status;
	}

	public void setConstructionTime(int turns) {
		constructionTime = turns;
	}

	public int getConstructionTime() {
		return constructionTime;
	}

	public void inConstruction(bool signal) {
		if (signal && !constructionComplete) {
			constructionTime--;
			if (constructionTime == 0) {
				constructionComplete = true;
			}
		}
	}

}
