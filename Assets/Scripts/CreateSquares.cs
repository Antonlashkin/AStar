using UnityEngine;
using UnityEngine.UI;

public class CreateSquares : MonoBehaviour
{
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private Text sizeX;
    private GameObject _square;

    private void Start()
    {
        for (int i = 0; i < CreateLayers.x; i++)
        {
            _square = Instantiate(squarePrefab, this.transform);
            if (CreateLayers.x % 2 == 1)
            {
                _square.transform.position = new Vector3(5.2f / Mathf.Max(CreateLayers.x, CreateLayers.y) * (i - CreateLayers.x / 2) + 0.2f / Mathf.Max(CreateLayers.x, CreateLayers.y) * i, 0, this.transform.position.z);
            }
            else
            {
                _square.transform.position = new Vector3((5.2f / Mathf.Max(CreateLayers.x, CreateLayers.y) * (i - CreateLayers.x / 2 + 1 / 2) + 0.2f / Mathf.Max(CreateLayers.x, CreateLayers.y) * i) + 5.2f / (2 * Mathf.Max(CreateLayers.x, CreateLayers.y)), 0, this.transform.position.z);
            }
            float scale = 5f / Mathf.Max(CreateLayers.x, CreateLayers.y);
            _square.transform.transform.localScale = new Vector3(scale,scale,scale);
        }
    }
}
