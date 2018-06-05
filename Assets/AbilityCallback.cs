using System.Collections;
using System.Collections.Generic;

public class AbilityCallback{
	private int _identifier;
	private List<Type> paramTypeList;
	private Delegate callback;

	public setAbilityCallback(Delegate delegate){
		callback = delegate;
	}
	
	public fireCallback(){
		
	}
}
