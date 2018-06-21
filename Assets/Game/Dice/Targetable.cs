using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Targetable : OnDieObj{

    private bool targetAcquired;
    private int maxNumOftargets;
    private List<OnDieObj> targetList;

    
    public bool acquireTarget(OnDieObj target){
        if(targetList.Count < maxNumOftargets){
            targetList.Add(target);
            return true;
        }else{
            targetAcquired = true;
            return false;
        }
	}
    public void clearTarget(){
        this.targetList.Clear();
        targetAcquired = false;
    }

    public void setTargetAcquired(bool status){
        this.targetAcquired = status;
    }

    public bool targetAcquiredStatus(){
        return targetAcquired;
    }
}