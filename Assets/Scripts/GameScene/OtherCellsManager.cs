using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCellsManager : MonoBehaviour
{
    public GameObject nodes;
    public GameObject other_cell_01;
    public GameObject other_cell_02;
    public GameObject other_cell_03;

    private const int MAX_OTHER_CELLS = 200;

    private List<GameObject> other_cell_list = new List<GameObject>();

    private void Start()
    {
        InitOtherCell();
    }

    private void FixedUpdate()
    {
        RespawnOtherCell();
    }

    private void InitOtherCell()
    {
        for (int i = 0; i < MAX_OTHER_CELLS; i++)
        {
            int idx = Random.Range(0, 3);
            float x = Random.Range(nodes.transform.GetChild(0).transform.position.x,
                nodes.transform.GetChild(2).transform.position.x);
            float y = Random.Range(nodes.transform.GetChild(0).transform.position.y,
                nodes.transform.GetChild(1).transform.position.y);
            float scale = Random.Range(0.02f, 1.5f);

            switch (idx)
            {
                case 0:
                    GameObject g1 = Instantiate(other_cell_01, new Vector3(x, y, 0), Quaternion.identity);
                    g1.transform.localScale = new Vector3(scale, scale, scale);
                    g1.transform.SetParent(transform);
                    other_cell_list.Add(g1);
                    break;
                case 1:
                    GameObject g2 = Instantiate(other_cell_02, new Vector3(x, y, 0), Quaternion.identity);
                    g2.transform.localScale = new Vector3(scale, scale, scale);
                    g2.transform.SetParent(transform);
                    other_cell_list.Add(g2);
                    break;
                case 2:
                    GameObject g3 = Instantiate(other_cell_03, new Vector3(x, y, 0), Quaternion.identity);
                    g3.transform.localScale = new Vector3(scale, scale, scale);
                    g3.transform.SetParent(transform);
                    other_cell_list.Add(g3);
                    break;
                default:
                    break;
            }
        }
    }

    private void RespawnOtherCell()
    {
        for (int i = 0; i < MAX_OTHER_CELLS; i++)
        {
            if (other_cell_list[i].transform.position.x < nodes.transform.GetChild(0).transform.position.x - 15)
            {
                RespawnOtherCellGetPoint(1, other_cell_list[i]);
            }
            else if (other_cell_list[i].transform.position.x > nodes.transform.GetChild(2).transform.position.x + 15)
            {
                RespawnOtherCellGetPoint(2, other_cell_list[i]);
            }
            else if (other_cell_list[i].transform.position.y > nodes.transform.GetChild(0).transform.position.y + 15)
            {
                RespawnOtherCellGetPoint(3, other_cell_list[i]);
            }
            else if (other_cell_list[i].transform.position.y < nodes.transform.GetChild(1).transform.position.y - 15)
            {
                RespawnOtherCellGetPoint(4, other_cell_list[i]);
            }
        }
    }

    private void RespawnOtherCellGetPoint(int _point, GameObject _g)
    {
        float x = 0;
        float y = 0;
        float scale = Random.Range(0.02f, 1.5f);

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
        _g.transform.localScale = new Vector3(scale, scale, scale);
    }
}
