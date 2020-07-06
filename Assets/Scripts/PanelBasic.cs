using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelBasic : MonoBehaviour
{
    [SerializeField] 
    private PlayerDB player_inventory;

    private GameObject audiomaster;
    private Text gene_amount;

    private void Start()
    {
        gene_amount = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
        gene_amount.text = player_inventory.GetPlayerGene().ToString();
        audiomaster = GameObject.FindGameObjectWithTag("audiomaster");
    }

    private void FixedUpdate()
    {
        gene_amount.text = player_inventory.GetPlayerGene().ToString();
    }

    public void GoBack()
    {
        audiomaster.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("MainScene");
    }

    private void DeduplicateInventory()
    {

    }
}
