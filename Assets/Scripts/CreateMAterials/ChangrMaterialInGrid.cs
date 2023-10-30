using UnityEngine;

public class ChangrMaterialInGrid : MonoBehaviour
{
    [SerializeField] Material forest;
    [SerializeField] Material lake;
    [SerializeField] Material block;
    [SerializeField] Material start;
    [SerializeField] Material finish;
    [SerializeField] Material standart;

    private void OnMouseDown()
    {
        switch (ChangeMaterialsInMemory.block)
        {
            case ChangeMaterialsInMemory.Blocks.Forest:
                transform.GetComponent<Renderer>().material = forest;
                break;
            case ChangeMaterialsInMemory.Blocks.Lake:
                transform.GetComponent<Renderer>().material = lake;
                break;
            case ChangeMaterialsInMemory.Blocks.Block:
                transform.GetComponent<Renderer>().material = block;
                break;
            case ChangeMaterialsInMemory.Blocks.Start:
                transform.GetComponent<Renderer>().material = start;
                break;
            case ChangeMaterialsInMemory.Blocks.Finish:
                transform.GetComponent<Renderer>().material = finish;
                break;
            case ChangeMaterialsInMemory.Blocks.Standart:
                transform.GetComponent<Renderer>().material = standart;
                break;
            default:
                break;
        }
    }
}
