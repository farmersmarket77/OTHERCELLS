using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneManager : MonoBehaviour
{
    [SerializeField] private PlayerDB player_inventory;

    private Text gene_txt;

    private void Start()
    {
        gene_txt = transform.GetChild(1).GetComponent<Text>();
        gene_txt.text = player_inventory.GetPlayerGene().ToString();
    }

    private void FixedUpdate()
    {
        UpdateGene();
    }

    private void UpdateGene()
    {
        gene_txt.text = player_inventory.GetPlayerGene().ToString();
    }
}
