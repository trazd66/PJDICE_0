using System;
using System.Collections;
using System.Collections.Generic;

namespace Callback
{	
	public delegate void eventVoidHandler(GameEvent targetEvent);
	public delegate bool eventBoolHandler(GameEvent targetEvent);
}

public abstract class CbHandler{
	private int _identifier;

	private GameEvent targetEvent;

	protected void setID(int id){
		this._identifier = id;
	}

	protected void setTargetEvent(GameEvent targetEvent){
		this.targetEvent = targetEvent;
	}

	protected GameEvent getTargetEvent(){
		return this.targetEvent;
	}

}

public class AbilityCallback :CbHandler{

	private Callback.eventVoidHandler handler;

	public AbilityCallback(int id){
		this.setID(id);	
	}

	public  void setHandler(Callback.eventVoidHandler cb){
		this.handler = cb;
	}

	public  void call(){
		handler(this.getTargetEvent());
	}

}

public class RequirementCallback : CbHandler{	
	private Boolean reqFullfilled;
	
	private Callback.eventBoolHandler handler;

	private Boolean reqChecked;
	private Boolean handlerIsSet;

	public RequirementCallback(int id){
		this.setID(id);
		reqFullfilled = false;
		reqChecked = false;
		handlerIsSet = false;
	}
	public  void setHandler(Callback.eventBoolHandler cb){
		this.handler = cb;
		handlerIsSet = true;
	}

	public  void call(){
		if(handlerIsSet){
			this.reqFullfilled = handler(this.getTargetEvent());
			reqChecked = true;
		}
	}

	public Boolean getReqFullfilled(){
		if(reqChecked){
			return this.reqFullfilled;
		}else{
			return false;
		}
	}

}