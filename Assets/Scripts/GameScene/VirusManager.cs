using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusManager : MonoBehaviour
{
    private VirusManager() { }
    public static VirusManager GetVirusmanager;

    public GameObject nodes;
    public GameObject virus_01;
    public GameObject virus_02;
    public GameObject virus_03;
    public GameObject whitecell;

    private const int MAX_VIRUS_NUM = 20;

    private List<GameObject> virus_list = new List<GameObject>();
    private float virus_speed;
    private bool virus_reverse;

    public List<GameObject> GetVirusList() { return virus_list; }
    public bool GetVirusReverse() { return virus_reverse; }
    public void SetVirusReverse(bool b) { virus_reverse = b; }
    
    private void Start()
    {
        GetVirusmanager = this;
        virus_speed = 3f;
        virus_reverse = false;

        InitVirus();

        StartCoroutine(VirusRoamGetDegree());
    }

    private void FixedUpdate()
    {
        RespawnVirus(); 
        VirusRoam();

        if (virus_reverse == false)
            VirusRun();
        else if (virus_reverse == true)
            VirusRunReverse();
    }

    private void InitVirus()
    {
        for (int i = 0; i < MAX_VIRUS_NUM; i++)
        {
            int idx = Random.Range(0, 3);
            float x = Random.Range(nodes.transform.GetChild(0).transform.position.x,
                nodes.transform.GetChild(2).transform.position.x);
            float y = Random.Range(nodes.transform.GetChild(0).transform.position.y,
                nodes.transform.GetChild(1).transform.position.y);

            switch (idx)
            {
                case 0:
                    GameObject g1 = Instantiate(virus_01, new Vector3(x, y, 0), Quaternion.identity);
                    g1.transform.SetParent(transform);
                    virus_list.Add(g1);
                    break;
                case 1:
                    GameObject g2 = Instantiate(virus_02, new Vector3(x, y, 0), Quaternion.identity);
                    g2.transform.SetParent(transform);
                    virus_list.Add(g2);
                    break;
                case 2:
                    GameObject g3 = Instantiate(virus_03, new Vector3(x, y, 0), Quaternion.identity);
                    g3.transform.SetParent(transform);
                    virus_list.Add(g3);
                    break;
                default:
                    break;
            }
        }
    }

    private void RespawnVirus()
    {
        if (virus_list.Count < MAX_VIRUS_NUM)
        {
            DeadRespawnVirus();
        }

        for (int i = 0; i < MAX_VIRUS_NUM; i++)
        {
            if (virus_list[i].transform.position.x < nodes.transform.GetChild(0).transform.position.x - 15)
            {
                RespawnVirusGetPoint(1, virus_list[i]);
            }
            else if (virus_list[i].transform.position.x > nodes.transform.GetChild(2).transform.position.x + 15)
            {
                RespawnVirusGetPoint(2, virus_list[i]);
            }
            else if (virus_list[i].transform.position.y > nodes.transform.GetChild(0).transform.position.y + 15)
            {
                RespawnVirusGetPoint(3, virus_list[i]);
            }
            else if (virus_list[i].transform.position.y < nodes.transform.GetChild(1).transform.position.y - 15)
            {
                RespawnVirusGetPoint(4, virus_list[i]);
            }
        }
    }

    private void RespawnVirusGetPoint(int _point, GameObject _g)
    {
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
        
    }

    private void DeadRespawnVirus()
    {
        int idx = Random.Range(0, 3);
        float x = Random.Range(nodes.transform.GetChild(0).transform.position.x,
            nodes.transform.GetChild(2).transform.position.x);
        float y = Random.Range(nodes.transform.GetChild(0).transform.position.y,
            nodes.transform.GetChild(1).transform.position.y);

        switch (idx)
        {
            case 0:
                GameObject g1 = Instantiate(virus_01, new Vector3(x, y, 0), Quaternion.identity);
                g1.transform.SetParent(transform);
                virus_list.Add(g1);
                break;
            case 1:
                GameObject g2 = Instantiate(virus_02, new Vector3(x, y, 0), Quaternion.identity);
                g2.transform.SetParent(transform);
                virus_list.Add(g2);
                break;
            case 2:
                GameObject g3 = Instantiate(virus_03, new Vector3(x, y, 0), Quaternion.identity);
                g3.transform.SetParent(transform);
                virus_list.Add(g3);
                break;
            default:
                break;
        }
    }

    private void VirusRun()
    {
        for (int i = 0; i < MAX_VIRUS_NUM; i++)
        {
            if (Vector3.Distance(whitecell.transform.position, virus_list[i].transform.position) < 8f)
            {
                float degree = Mathf.Atan2(whitecell.transform.position.y - virus_list[i].transform.position.y,
                    whitecell.transform.position.x - virus_list[i].transform.position.x) * 180f / Mathf.PI;
                virus_list[i].transform.rotation = Quaternion.Euler(0, 0, degree);
                virus_list[i].transform.Translate(Vector3.left * Time.deltaTime * virus_speed);
            }
        }
    }

    private void VirusRunReverse()
    {
        for (int i = 0; i < MAX_VIRUS_NUM; i++)
        {
            if (Vector3.Distance(whitecell.transform.position, virus_list[i].transform.position) > 1f)
            {
                float degree = Mathf.Atan2(whitecell.transform.position.y - virus_list[i].transform.position.y,
                    whitecell.transform.position.x - virus_list[i].transform.position.x) * 180f / Mathf.PI;
                virus_list[i].transform.rotation = Quaternion.Euler(0, 0, degree);
                virus_list[i].transform.Translate(Vector3.right * Time.deltaTime * virus_speed * 3);
            }
        }
    }

    private void VirusRoam()
    {
        for (int i = 0; i < MAX_VIRUS_NUM; i++)
        {
            virus_list[i].transform.Translate(Vector3.left * Time.deltaTime * virus_speed / 2);
        }
    }
    
    private IEnumerator VirusRoamGetDegree()
    {
        while (true)
        {
            for (int i = 0; i < MAX_VIRUS_NUM; i++)
            {
                float rnd_degree = Random.Range(0, 361);

                float degree = Mathf.Atan2(whitecell.transform.position.y - virus_list[i].transform.position.y,
                           whitecell.transform.position.x - virus_list[i].transform.position.x) * rnd_degree / Mathf.PI;
                virus_list[i].transform.rotation = Quaternion.Euler(0, 0, degree);
            }

            yield return new WaitForSeconds(2f);
        }
    }

    
}