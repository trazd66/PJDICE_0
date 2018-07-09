using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructCard : Card{

    private int hp;
    
    private int movesPerTurn;

    private AOEtype targetAOEtype;
    private int numOfTargets;
    private int turnsToBuild;

    public ConstructCard(string name, int identifier) :base(name,identifier){

    }
    public ConstructCard(ConstructCardDesc desc):base(desc){
        this.hp = desc.hp;
        this.movesPerTurn = desc.movesPerTurn;
        this.targetAOEtype = desc.targetAOEtype;
        this.numOfTargets = desc.numOfTargets;
        this.turnsToBuild = desc.turnsToBuild;
    }


    public void setHp(int hp){
        this.hp = hp;
    }
	public void setMovesPerTurn(int movesPerTurn){
        this.movesPerTurn = movesPerTurn;
    }
	public void setAOEtype(AOEtype targetAOEtype){
        this.targetAOEtype = targetAOEtype;
    }
	public void setNumOftarget(int numOfTargets){
        this.numOfTargets = numOfTargets;
    }
	public void setTurnsTobuild(int turnsToBuild){
        this.turnsToBuild = turnsToBuild;
    }

    public  Construct build(){
        return null;
    }

    public ConstructCard():base(){
    }

}