using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity{
	COMMON = (1<<0)
}
public enum CardSet{
	BASIC = (1 << 0)
}

public enum CardType{
	CONSTRUCT = (1 << 0),
	SPELL = (1 << 1)
}


public abstract class CardDesc{
    public int id;
	public string name;
	public string description;
	public CardType type;
	public Rarity rarity;
	public bool collectible = true;
	public CardSet set;
    public abstract CardDesc createInstance(string jsonString);
}