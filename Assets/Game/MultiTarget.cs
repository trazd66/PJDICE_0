
public enum AOEtype{
	Linear = ( 1 << 0 ),
	Circular = (1 << 1)
}
public struct MultiTarget{
	public AOEtype aoeType;
	public int numOfTargets;
}