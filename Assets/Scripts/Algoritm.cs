using UnityEngine;

public class Algoritm : MonoBehaviour
{
    [SerializeField] private GameObject FLD;
    [SerializeField] private int forrestCost;
    [SerializeField] private int lakeCost;
    [SerializeField] private int standartCost;
    [SerializeField] private GameObject arrowPefab;
    [SerializeField] private GameObject materialsPanel;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject nextButton;


    private GameObject _arrow;
    private Square start = new Square();
    private Square finish = new Square();
    private Square now = new Square();
    private Square next = new Square();

    private Square[,] field;
    public void CreateGrid()
    {
        field = new Square[CreateLayers.y, CreateLayers.x];

        int isStart = 0;
        int isFinish = 0;

        for (int i = 0; i < CreateLayers.y; i++)
        {
            for (int j = 0; j < CreateLayers.x; j++)
            {
                Material material = FLD.transform.GetChild(i).GetChild(j).GetComponent<Renderer>().material;
                field[i, j] = new Square();
                field[i, j].X = j;
                field[i, j].Y = i;
                switch (material.name)
                {
                    case "Start (Instance)":
                        start = field[i, j];
                        field[i, j].Cost = standartCost;
                        field[i, j].SumCost = 0;
                        isStart++;
                        break;
                    case "Finish (Instance)":
                        finish = field[i, j];
                        field[i, j].Cost = standartCost;
                        isFinish++;
                        break;
                    case "Forrest (Instance)":
                        field[i, j].Cost = forrestCost;
                        break;

                    case "Lake (Instance)":
                        field[i, j].Cost = lakeCost;
                        break;
                    case "Let (Instance)":
                        field[i, j].IsBlocked = true;
                        break;
                    case "Default (Instance)":
                        field[i, j].Cost = standartCost;
                        break;
                }
            }
        }
        if (isFinish == 1 && isStart == 1)
        {
            now = start;
            nextButton.SetActive(true);
            Destroy(materialsPanel);
            Destroy(button);
        }
    }

    public void NextStep()
    {
        int jMin = -1;
        int jMax = 1;
        int iMin = -1;
        int iMax = 1;
        float minValue = Mathf.Infinity;

        if (now.X == 0)
        {
            jMin = 0;
        }
        if (now.X == CreateLayers.x - 1)
        {
            jMax = 0;
        }



        if (now.Y == 0)
        {
            iMin = 0;
        }
        if (now.Y == CreateLayers.y -1)
        {
            iMax = 0;
        }


        for (int i = iMin; i <= iMax; i++)
        {
            for (int j = jMin; j <= jMax; j++)
            {
                if ((i == 0 && j == 0) || field[i + now.Y, j + now.X].IsBlocked)
                {
                    continue;
                }


                int wayFromStartNow = (int)(field[i + now.Y, j + now.X].Cost * Mathf.Sqrt(Mathf.Pow(i, 2) + Mathf.Pow(j, 2))) + now.WayFromStart;
                if (field[i + now.Y, j + now.X].WayFromStart > wayFromStartNow || field[i + now.Y, j + now.X].WayFromStart == 0)
                {             
                    _arrow = Instantiate(arrowPefab);
                    if (field[i + now.Y, j + now.X].Arrow != null)
                    {
                        Destroy(field[i + now.Y, j + now.X].Arrow);
                    }
                    _arrow.transform.position = FLD.transform.GetChild(i + now.Y).GetChild(j + now.X).transform.position;
                    _arrow.transform.Translate(0, 2, 0); 
                    field[i + now.Y, j + now.X].Arrow = _arrow;
                    if (j == 0)
                    {
                        _arrow.transform.rotation = Quaternion.Euler(0,  (90 * (i + 1)), 0);
                    }
                    else if (i == 0)
                    {
                        _arrow.transform.rotation = Quaternion.Euler(0, (90 * -j), 0);
                    }
                    else if (i == 1)
                    {
                        _arrow.transform.rotation = Quaternion.Euler(0, (135 * -j), 0);
                    }
                    else if (i == -1)
                    {
                        _arrow.transform.rotation = Quaternion.Euler(0, (45 * -j), 0);
                    }
                    //Spawn Arrow
                    field[i + now.Y, j + now.X].WayFromStart = wayFromStartNow;
                }
                if (FLD.transform.GetChild(i + now.Y).GetChild(j + now.X).GetComponent<Renderer>().material.name == "Finish (Instance)")
                {
                    return;
                }
                field[i + now.Y, j + now.X].SumCost = field[i + now.Y, j + now.X].WayFromStart + standartCost * (Mathf.Abs(now.X + j - finish.X) + Mathf.Abs(now.Y + i - finish.Y));
            }
        }

        for (int i = 0; i < CreateLayers.y; i++)
        {
            for (int j = 0; j < CreateLayers.x; j++)
            {
                if (field[i, j].SumCost == 0 || field[i, j].IsBlocked || (field[i, j].X == now.X && field[i, j].Y == now.Y))
                {
                    continue;
                }
                if (field[i, j].SumCost < minValue)
                {
                    next = field[i, j];
                    minValue = next.SumCost;
                }
            }
        }
        minValue = Mathf.Infinity;
        now.IsBlocked = true;
        now = next;
    }
}
