using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiegeConstruct: Construct{
   private int damage;

   private int hp;
   
   private int movesPerTurn;

   private bool isAOEDmaage;



   public void setDamage(int damage){
       this.damage = damage;
   }

   public void setHP(int hp){
       this.hp = hp;
   }

   public int getDamage(){
       return this.damage;
   }

   public int getHP(){
       return this.hp;
   }

}