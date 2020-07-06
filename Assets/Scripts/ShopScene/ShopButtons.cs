using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopButtons : MonoBehaviour
{
    [SerializeField] 
    private PlayerDB player_DB;
    [SerializeField] 
    private ClothesListDB closet_list_DB;

    private GameObject audiomaster;
    private AudioSource audio_purchase;
    
    private void Start()
    {
        audiomaster = GameObject.FindGameObjectWithTag("audiomaster");
        audio_purchase = audiomaster.transform.GetChild(1).GetChild(1).GetComponent<AudioSource>();

        InitScene();
    }
    
    private void InitScene()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            if (closet_list_DB.GetClothesAccese()[i] == true)
                transform.GetChild(0).GetChild(i).GetComponent<Button>().interactable = false;
            else
                transform.GetChild(0).GetChild(i).GetComponent<Button>().interactable = true;

            transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = closet_list_DB.GetClothesListDB()[i];
        }
    }

    #region buttons

    public void BuyClothes_01()
    {
        if (closet_list_DB.GetClothesAccese()[0] == true)
            return;
        else
        {
            audio_purchase.Play();
            player_DB.GetPlayerClothesInventory().Add(closet_list_DB.GetClothesListDB()[0]);
            closet_list_DB.GetClothesAccese()[0] = true;
        }

        player_DB.ClosetClear();
        InitScene();
    }
    public void BuyClothes_02()
    {
        if (closet_list_DB.GetClothesAccese()[1] == true)
            return;
        else
        {
            audio_purchase.Play();
            player_DB.GetPlayerClothesInventory().Add(closet_list_DB.GetClothesListDB()[1]);
            closet_list_DB.GetClothesAccese()[1] = true;
        }

        player_DB.ClosetClear();
        InitScene();
    }
    public void BuyClothes_03()
    {
        if (closet_list_DB.GetClothesAccese()[2] == true)
            return;
        else
        {
            audio_purchase.Play();
            player_DB.GetPlayerClothesInventory().Add(closet_list_DB.GetClothesListDB()[2]);
            closet_list_DB.GetClothesAccese()[2] = true;
        }

        player_DB.ClosetClear();
        InitScene();
    }
    public void BuyClothes_04()
    {
        if (closet_list_DB.GetClothesAccese()[3] == true)
            return;
        else
        {
            audio_purchase.Play();
            player_DB.GetPlayerClothesInventory().Add(closet_list_DB.GetClothesListDB()[3]);
            closet_list_DB.GetClothesAccese()[3] = true;
        }

        player_DB.ClosetClear();
        InitScene();
    }
    public void BuyClothes_05()
    {
        if (closet_list_DB.GetClothesAccese()[4] == true)
            return;
        else
        {
            audio_purchase.Play();
            player_DB.GetPlayerClothesInventory().Add(closet_list_DB.GetClothesListDB()[4]);
            closet_list_DB.GetClothesAccese()[4] = true;
        }

        player_DB.ClosetClear();
        InitScene();
    }
    public void BuyClothes_06()
    {
        if (closet_list_DB.GetClothesAccese()[5] == true)
            return;
        else
        {
            audio_purchase.Play();
            player_DB.GetPlayerClothesInventory().Add(closet_list_DB.GetClothesListDB()[5]);
            closet_list_DB.GetClothesAccese()[5] = true;
        }

        player_DB.ClosetClear();
        InitScene();
    }
    public void BuyClothes_07()
    {
        if (closet_list_DB.GetClothesAccese()[6] == true)
            return;
        else
        {
            audio_purchase.Play();
            player_DB.GetPlayerClothesInventory().Add(closet_list_DB.GetClothesListDB()[6]);
            closet_list_DB.GetClothesAccese()[6] = true;
        }

        player_DB.ClosetClear();
        InitScene();
    }

    #endregion
}
