using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public GameObject nodes;
    public GameObject flooding_cells_1;
    public GameObject flooding_cells_2;
    public GameObject flooding_cells_3;

    private const int MAX_FLOODING_CELLS = 30;

    private List<GameObject> flooding_cells_list = new List<GameObject>();
    private float rotation;

    private void Start()
    {
        InitFloodingCell();
    }

    private void FixedUpdate()
    {
        RespawnFloodingCell();
    }

    private void InitFloodingCell()
    {
        for (int i = 0; i < MAX_FLOODING_CELLS; i++)
        {
            rotation = Random.Range(0, 361);
            int idx = Random.Range(0, 3);
            float x = Random.Range(nodes.transform.GetChild(0).transform.position.x,
                nodes.transform.GetChild(2).transform.position.x);
            float y = Random.Range(nodes.transform.GetChild(0).transform.position.y,
                nodes.transform.GetChild(1).transform.position.y);

            switch (idx)
            {
                case 0:
                    GameObject _g1 = Instantiate(flooding_cells_1, new Vector3(x, y, 0), Quaternion.Euler(new Vector3(0, 0, rotation)));
                    _g1.transform.SetParent(transform.GetChild(1));
                    flooding_cells_list.Add(_g1);
                    break;
                case 1:
                    GameObject _g2 = Instantiate(flooding_cells_2, new Vector3(x, y, 0), Quaternion.Euler(new Vector3(0, 0, rotation)));
                    _g2.transform.SetParent(transform.GetChild(1));
                    flooding_cells_list.Add(_g2);
                    break;
                case 2:
                    GameObject _g3 = Instantiate(flooding_cells_3, new Vector3(x, y, 0), Quaternion.Euler(new Vector3(0, 0, rotation)));
                    _g3.transform.SetParent(transform.GetChild(1));
                    flooding_cells_list.Add(_g3);
                    break;
                default:
                    break;
            }
        }
    }
    
    private void RespawnFloodingCell()
    {
        for (int i = 0; i < MAX_FLOODING_CELLS; i++)
        {
            if (flooding_cells_list[i].transform.position.x < nodes.transform.GetChild(0).transform.position.x)
            {
                RespawnFloodingCellGetPoint(1,flooding_cells_list[i]);
            }
            else if (flooding_cells_list[i].transform.position.x > nodes.transform.GetChild(2).transform.position.x)
            {
                RespawnFloodingCellGetPoint(2,flooding_cells_list[i]);
            }
            else if (flooding_cells_list[i].transform.position.y > nodes.transform.GetChild(0).transform.position.y)
            {
                RespawnFloodingCellGetPoint(3,flooding_cells_list[i]);
            }
            else if (flooding_cells_list[i].transform.position.y < nodes.transform.GetChild(1).transform.position.y)
            {
                RespawnFloodingCellGetPoint(4,flooding_cells_list[i]);
            }
        }
    }

    private void RespawnFloodingCellGetPoint(int _point, GameObject _g)
    {
        rotation = Random.Range(0, 361);
        float x = 0;
        float y = 0;

        switch (_point)
        {
            case 1:
                x = nodes.transform.GetChild(2).transform.position.x;
                y = Random.Range(nodes.transform.GetChild(0).transform.position.y,
                    nodes.transform.GetChild(1).transform.position.y);
                break;
            case 2:
                x = nodes.transform.GetChild(1).transform.position.x;
                y = Random.Range(nodes.transform.GetChild(0).transform.position.y,
                    nodes.transform.GetChild(1).transform.position.y);
                break;
            case 3:
                x = Random.Range(nodes.transform.GetChild(0).transform.position.x,
                    nodes.transform.GetChild(2).transform.position.x);
                y = nodes.transform.GetChild(3).transform.position.y;
                break;
            case 4:
                x = Random.Range(nodes.transform.GetChild(0).transform.position.x,
                    nodes.transform.GetChild(2).transform.position.x);
                y = nodes.transform.GetChild(0).transform.position.y;
                break;
            default:
                break;
        }

        _g.transform.position = new Vector3(x, y, 0);
        _g.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
    }

}
