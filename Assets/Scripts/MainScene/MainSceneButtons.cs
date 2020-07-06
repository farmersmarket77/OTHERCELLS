using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneButtons : MonoBehaviour
{
    private GameObject audiomaster;
    private GameObject UI_animmaster;

    private void Start()
    {
        audiomaster = GameObject.FindGameObjectWithTag("audiomaster");
        UI_animmaster = GameObject.FindGameObjectWithTag("ui_animmaster");
    }

    public void StartButton()
    {
        audiomaster.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().Play();
        audiomaster.GetComponent<AudioMaster>().SwitchBGM(2);
        StartCoroutine(UI_animmaster.GetComponent<UIAnimMaster>().
            ButtonTapAnim(transform.GetChild(2).gameObject, "GameScene"));
    }

    public void ShopButton()
    {
        audiomaster.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().Play();
        StartCoroutine(UI_animmaster.GetComponent<UIAnimMaster>().
            ButtonTapAnim(transform.GetChild(3).gameObject, "ShopScene"));
    }

    public void ClosetButton()
    {
        audiomaster.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().Play();
        StartCoroutine(UI_animmaster.GetComponent<UIAnimMaster>().
            ButtonTapAnim(transform.GetChild(4).gameObject, "ClosetScene"));
    }

    public void ExitButton()
    {
        audiomaster.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().Play();
        StartCoroutine(UI_animmaster.GetComponent<UIAnimMaster>().
            ButtonTapAnim(transform.GetChild(5).gameObject));

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
        Application.Quit();
#endif
    }

    public void OptionOpenButton()
    {
        audiomaster.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().Play();
        transform.GetChild(6).gameObject.SetActive(true);
        StartCoroutine(PanelOption.paneloption.OpenAnim());
    }
}
