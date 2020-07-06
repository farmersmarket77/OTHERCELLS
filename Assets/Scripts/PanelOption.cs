using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelOption: MonoBehaviour
{
    private PanelOption() { }
    public static PanelOption paneloption = null;

    [SerializeField]
    private PlayerDB player_DB;
    private GameObject audiomaster;
    private GameObject UI_animmaster;
    private AudioSource[] audio_bgm;
    private AudioSource[] audio_sfx;
    private float audio_bgm_val;
    private float audio_sfx_val;
    private float panel_width;
    private float panel_height;

    public float GetAudioBGMVal() { return audio_bgm_val; }
    public float GetAudioSFXVal() { return audio_sfx_val; }

    private void Awake()
    {
        if (paneloption == null)
            paneloption = this;
        else if (paneloption != null)
            Destroy(gameObject);
    }

    private void Start()
    {
        InitOptionPanel();
    }
    
    private void Update()
    {
        SoundSlider();
    }
    private void InitOptionPanel()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(5).gameObject.SetActive(true);
            transform.GetChild(6).gameObject.SetActive(true);
        }

        audiomaster = GameObject.FindGameObjectWithTag("audiomaster");
        UI_animmaster = GameObject.FindGameObjectWithTag("ui_animmaster");
        panel_width = transform.GetComponent<RectTransform>().localScale.x;
        panel_height = transform.GetComponent<RectTransform>().localScale.y;
        audio_bgm = new AudioSource[audiomaster.transform.GetChild(0).childCount];
        audio_sfx = new AudioSource[audiomaster.transform.GetChild(1).childCount];

        for (int i = 0; i < audio_bgm.Length; i++)
        {
            audio_bgm[i] = audiomaster.transform.GetChild(0).GetChild(i).GetComponent<AudioSource>();
        }
        for (int i = 0; i < audio_sfx.Length; i++)
        {
            audio_sfx[i] = audiomaster.transform.GetChild(1).GetChild(i).GetComponent<AudioSource>();
        }

        audio_bgm_val = player_DB.GetPlayerBGMVolume();
        transform.GetChild(4).GetComponent<Slider>().value = audio_bgm_val;
        for (int i = 0; i < audio_bgm.Length; i++)
        {
            audio_bgm[i].volume = transform.GetChild(4).GetComponent<Slider>().value;
        }

        audio_sfx_val = player_DB.GetPlayerSFXVolume();
        transform.GetChild(5).GetComponent<Slider>().value = audio_sfx_val;
        for (int i = 0; i < audio_sfx.Length; i++)
        {
            audio_sfx[i].volume = transform.GetChild(5).GetComponent<Slider>().value;
        }

        gameObject.SetActive(false);
    }

    private void SoundSlider()
    {
        for (int i = 0; i < audio_bgm.Length; i++)
        {
            audio_bgm[i].volume = transform.GetChild(4).GetComponent<Slider>().value;
        }
        audio_bgm_val = transform.GetChild(4).GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("audio_bgm_val", audio_bgm_val);

        for (int i = 0; i < audio_sfx.Length; i++)
        {
            audio_sfx[i].volume = transform.GetChild(5).GetComponent<Slider>().value;
        }
        audio_sfx_val = transform.GetChild(5).GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("audio_sfx_val", audio_sfx_val);

        player_DB.SetPlayerBGMVolume(audio_bgm_val);
        player_DB.SetPlayerSFXVolume(audio_sfx_val);
    }

    public void OptionCloseButton()
    {
        audiomaster.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().Play();
        StartCoroutine(CloseAnim());
    }

    public void SelectBGM_01_Button()
    {
        player_DB.SetPlayerCurrentBGM(audiomaster.transform.GetChild(0).GetChild(0).GetComponent<AudioSource>());
        audiomaster.GetComponent<AudioMaster>().SwitchBGM(0);
        StartCoroutine(UI_animmaster.GetComponent<UIAnimMaster>().
            ButtonTapAnim(transform.GetChild(6).gameObject));
    }

    public void SelectBGM_02_Button()
    {
        player_DB.SetPlayerCurrentBGM(audiomaster.transform.GetChild(0).GetChild(1).GetComponent<AudioSource>());
        audiomaster.GetComponent<AudioMaster>().SwitchBGM(1);
        StartCoroutine(UI_animmaster.GetComponent<UIAnimMaster>().
            ButtonTapAnim(transform.GetChild(7).gameObject));
    }

    private IEnumerator CloseAnim()
    {
        Color tmp_color;
        float time_closing = 0.2f;
        float x = panel_width;
        float y = panel_height;

        tmp_color = transform.GetComponent<Image>().color;
        transform.GetComponent<Image>().color = transform.GetChild(0).GetComponent<Image>().color;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        while (x > 0)
        {
            time_closing -= Time.deltaTime;
            x -= 0.1f;
            y -= 0.1f;

            transform.GetComponent<RectTransform>().localScale = new Vector2(x, y);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        transform.GetComponent<RectTransform>().localScale = new Vector2(panel_width, panel_height);
        transform.GetComponent<Image>().color = tmp_color;

        gameObject.SetActive(false);
    }

    public IEnumerator OpenAnim()
    {
        float x = panel_width;
        float y = panel_height;

        transform.GetComponent<RectTransform>().localScale = new Vector2(x, y);

        while (x < panel_width + 0.05f)
        {
            x += 0.015f;
            y += 0.015f;

            transform.GetComponent<RectTransform>().localScale = new Vector2(x, y);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        while (x > panel_width)
        {
            x -= 0.015f;
            y -= 0.015f;

            transform.GetComponent<RectTransform>().localScale = new Vector2(x, y);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
