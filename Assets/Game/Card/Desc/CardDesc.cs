public abstract class CardDesc{
    public string id;
	public string name;
	public string description;
	public bool collectible = true;

    public abstract Card create();
}