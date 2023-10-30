using UnityEngine;
using UnityEngine.UI;

public class CreateLayers : MonoBehaviour
{
    [SerializeField] private GameObject layerPrefab;
    [SerializeField] private Text sizeX;
    [SerializeField] private Text sizeY;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject nextButton;
    private GameObject _layer;
    public static int x = 0;
    public static int y = 0;

    public void MakeGrid()
    {
        if (int.TryParse(sizeX.text, out x) && int.TryParse(sizeY.text, out y))
        {
            if (x > 0 && x <= 10 && y > 0 && y <= 10)
            {
                for (float i = 0; i < y; i++)
                {
                    //Debug.Log("Layers");
                    _layer = Instantiate(layerPrefab, this.transform);
                    if (y % 2 == 1)
                    {
                        _layer.transform.position = new Vector3(0, 0, 5.2f / Mathf.Max(x, y) * (i - y / 2) + 0.2f / Mathf.Max(x, y) * i);
                    }
                    else
                    {
                        //Debug.Log((i - y / 2) + 1 / 2);
                        _layer.transform.position = new Vector3(0, 0, (5.2f / Mathf.Max(x, y) * (i - y / 2) + 0.2f / Mathf.Max(x, y) * i) + 5.2f / (2 * Mathf.Max(x, y)));
                    }
                }
                nextButton.SetActive(true);
                Destroy(button);
            }
        }
    }
}
