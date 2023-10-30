using UnityEngine;

public class ChangeMaterialsInMemory : MonoBehaviour
{
    public enum Blocks
    {Forest,
    Lake,
    Block,
    Start,
    Finish,
    Standart
    }

    public static Blocks block = Blocks.Standart;

    public void Forest()
    {
        block = Blocks.Forest;
    }

    public void Lake()
    {
        block = Blocks.Lake;
    }

    public void Block()
    {
        block = Blocks.Block;
    }

    public void Start1()
    {
        block = Blocks.Start;
    }

    public void Finish()
    {
        block = Blocks.Finish;
    }

    public void Standart()
    {
        block = Blocks.Standart;
    }
}
