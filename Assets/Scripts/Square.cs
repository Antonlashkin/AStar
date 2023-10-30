using UnityEngine;

public class Square 
{
	private GameObject arrow;
    private int sumCost;
	private int wayFromStart;
    private bool isBlocked;
    private int cost;
	private int x;
	private int y;


	public GameObject Arrow
	{
		get { return arrow; }
		set { arrow = value; }
	}


	public int SumCost
	{
		get { return sumCost; }
		set { sumCost = value; }
	}


	public bool IsBlocked
	{
		get { return isBlocked; }
		set { isBlocked = value; }
	}

    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }

	public int X
	{
		get { return x; }
		set { x = value; }
	}
    public int Y
    {
        get { return y; }
        set { y = value; }
    }

	public int WayFromStart
	{
		get { return wayFromStart; }
		set { wayFromStart = value; }
	}

}
