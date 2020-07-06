using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMaster : MonoBehaviour
{
    private AudioMaster() { }
    public static AudioMaster audiomaster = null;

    [SerializeField]
    private PlayerDB player_DB;
    private GameObject[] arr_BGM;
    private AudioSource current_BGM;

    public AudioSource GetCurrentBGM() { return current_BGM; }
    public void SetCurrentBGM(AudioSource a) { current_BGM = a; }

    private void Awake()
    {
        if (audiomaster == null)
            audiomaster = this;
        else if (audiomaster != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitAudioMaster();
    }

    private void InitAudioMaster()
    {
        arr_BGM = new GameObject[transform.GetChild(0).childCount];
        current_BGM = player_DB.GetPlayerCurrentBGM();

        for (int i = 0; i < arr_BGM.Length; i++)
        {
            arr_BGM[i] = transform.GetChild(0).GetChild(i).gameObject;
        }

        for (int i = 0; i < arr_BGM.Length; i++)
        {
            if (arr_BGM[i].GetComponent<AudioSource>().isPlaying == true)
            {
                arr_BGM[i].GetComponent<AudioSource>().Stop();
            }
        }

        if (player_DB.GetPlayerCurrentBGM() == null)
            player_DB.SetPlayerCurrentBGM(arr_BGM[0].GetComponent<AudioSource>());

        if (current_BGM == null)
        {
            current_BGM = player_DB.GetPlayerCurrentBGM();
        }
        else if (current_BGM != null)
            current_BGM.Stop();

        PlayBGM();
    }

    public void SwitchBGM(int bgm_idx)
    {
        current_BGM.Stop();
        current_BGM = arr_BGM[bgm_idx].GetComponent<AudioSource>();
        PlayBGM();
    }

    public void SwitchBGM(AudioSource _a)
    {
        current_BGM.Stop();
        current_BGM = _a;
        PlayBGM();
    }

    public void PlayBGM()
    {
        current_BGM.Play();
    }
}
