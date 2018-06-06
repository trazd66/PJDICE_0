using System;
using System.Collections;
using System.Collections.Generic;

public class AbilityCallback{
	private int _identifier;
	private List<Type> paramTypeList;
	private Delegate callback;

	public void setAbilityCallback(Delegate cb){
		callback = cb;
	}
	
	public void fireCallback(){
		
	}
}