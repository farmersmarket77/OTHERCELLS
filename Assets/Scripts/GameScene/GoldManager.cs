using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    private GoldManager() { }
    public static GoldManager getGoldmanager;

    private Text gold_txt;
    private int gold;

    public int GetGold() { return gold; }
    public void SetGold(int n) { gold = n; }

    private void Start()
    {
        getGoldmanager = this;
        gold_txt = transform.GetChild(1).GetComponent<Text>();
        gold_txt.text = "0";
        gold = 0;
    }

    private void FixedUpdate()
    {
        UpdateGold();
    }

    private void UpdateGold()
    {
        gold_txt.text = gold.ToString();
    }
}
