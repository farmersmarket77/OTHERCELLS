using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    [SerializeField]
    private PlayerDB player_DB;
    private GameObject audiomaster;

    private void Start()
    {
        audiomaster = GameObject.FindGameObjectWithTag("audiomaster");
    }

    public void PauseGame()
    {
        audiomaster.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().Play();
        transform.GetChild(8).gameObject.SetActive(true);
        StartCoroutine(PanelOption.paneloption.OpenAnim());
    }

    public void GoBack()
    {
        audiomaster.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().Play();
        audiomaster.GetComponent<AudioMaster>().SwitchBGM(player_DB.GetPlayerCurrentBGM());
        SceneManager.LoadScene("MainScene");
    }
}
