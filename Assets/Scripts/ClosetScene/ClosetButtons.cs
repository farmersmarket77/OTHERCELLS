using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClosetButtons : MonoBehaviour
{
    [SerializeField]
    private PlayerDB player_DB;
    [SerializeField]
    private ClothesListDB closet_list_DB;

    private GameObject audiomaster;
    private AudioSource audio_tap;

    private void Start()
    {
        audiomaster = GameObject.FindGameObjectWithTag("audiomaster");
        audio_tap = audiomaster.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>();

        InitScene();
    }

    private void InitScene()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            if (closet_list_DB.GetClothesAccese()[i] == false)
                transform.GetChild(0).GetChild(i).GetComponent<Button>().interactable = false;
            else
                transform.GetChild(0).GetChild(i).GetComponent<Button>().interactable = true;

            transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = closet_list_DB.GetClothesListDB()[i];
        }
    }

    #region buttons

    public void Clothes_01()
    {
        if (closet_list_DB.GetClothesAccese()[0] == false)
            return;
        else
        {
            audio_tap.Play();
            player_DB.SetPlayerCurrentClothes(closet_list_DB.GetClothesListDB()[0]);
        }

        InitScene();
    }
    public void Clothes_02()
    {
        if (closet_list_DB.GetClothesAccese()[1] == false)
            return;
        else
        {
            audio_tap.Play();
            player_DB.SetPlayerCurrentClothes(closet_list_DB.GetClothesListDB()[1]);
        }

        InitScene();
    }
    public void Clothes_03()
    {
        if (closet_list_DB.GetClothesAccese()[2] == false)
            return;
        else
        {
            audio_tap.Play();
            player_DB.SetPlayerCurrentClothes(closet_list_DB.GetClothesListDB()[2]);
        }

        InitScene();
    }
    public void Clothes_04()
    {
        if (closet_list_DB.GetClothesAccese()[3] == false)
            return;
        else
        {
            audio_tap.Play();
            player_DB.SetPlayerCurrentClothes(closet_list_DB.GetClothesListDB()[3]);
        }

        InitScene();
    }
    public void Clothes_05()
    {
        if (closet_list_DB.GetClothesAccese()[4] == false)
            return;
        else
        {
            audio_tap.Play();
            player_DB.SetPlayerCurrentClothes(closet_list_DB.GetClothesListDB()[4]);
        }

        InitScene();
    }
    public void Clothes_06()
    {
        if (closet_list_DB.GetClothesAccese()[5] == false)
            return;
        else
        {
            audio_tap.Play();
            player_DB.SetPlayerCurrentClothes(closet_list_DB.GetClothesListDB()[5]);
        }

        InitScene();
    }
    public void Clothes_07()
    {
        if (closet_list_DB.GetClothesAccese()[6] == false)
            return;
        else
        {
            audio_tap.Play();
            player_DB.SetPlayerCurrentClothes(closet_list_DB.GetClothesListDB()[6]);
        }

        InitScene();
    }

    #endregion

}
