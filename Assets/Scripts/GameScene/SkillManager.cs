/*
 * ***************  skill infom ***************
 * 
 *      skill 01 -> recover HP
 *      skill 02 -> magnet
 *      skill 03 -> move faster
 *      
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    private const float skill_01_EFFECTTIME = 0f;
    private const float skill_02_EFFECTTIME = 3f;
    private const float skill_03_EFFECTTIME = 5f;
    private const float skill_01_COOLTIME = 5f;
    private const float skill_02_COOLTIME = 10f;
    private const float skill_03_COOLTIME = 5f;

    private GameObject audiomaster;
    private AudioSource audio_skill_use;
    private AudioSource audio_skill_cooltime_end;
    private Button skill_01_button;
    private Button skill_02_button;
    private Button skill_03_button;
    private Image skill_01_image;
    private Image skill_02_image;
    private Image skill_03_image;
    private Image skill_01_effecttime_image;
    private Image skill_02_effecttime_image;
    private Image skill_03_effecttime_image;
    private Text skill_01_cooltime_text;
    private Text skill_02_cooltime_text;
    private Text skill_03_cooltime_text;
    private Animator skill_01_cooltime_effect_anim;
    private Animator skill_02_cooltime_effect_anim;
    private Animator skill_03_cooltime_effect_anim;
    private float skill_01_time;
    private float skill_02_time;
    private float skill_03_time;

    private void Start()
    {
        audiomaster = GameObject.FindGameObjectWithTag("audiomaster");
        audio_skill_use = audiomaster.transform.GetChild(1).GetChild(2).GetComponent<AudioSource>();
        audio_skill_cooltime_end = audiomaster.transform.GetChild(1).GetChild(3).GetComponent<AudioSource>();
        skill_01_button = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        skill_02_button = transform.GetChild(1).GetChild(1).GetComponent<Button>();
        skill_03_button = transform.GetChild(2).GetChild(1).GetComponent<Button>();
        skill_01_image = transform.GetChild(0).GetChild(1).GetComponent<Image>();
        skill_02_image = transform.GetChild(1).GetChild(1).GetComponent<Image>();
        skill_03_image = transform.GetChild(2).GetChild(1).GetComponent<Image>();
        skill_01_effecttime_image = transform.GetChild(3).GetComponent<Image>();
        skill_02_effecttime_image = transform.GetChild(4).GetComponent<Image>();
        skill_03_effecttime_image = transform.GetChild(5).GetComponent<Image>();
        skill_01_cooltime_text = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        skill_02_cooltime_text = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        skill_03_cooltime_text = transform.GetChild(2).GetChild(0).GetComponent<Text>();
        skill_01_cooltime_effect_anim = transform.GetChild(0).GetChild(2).GetComponent<Animator>();
        skill_02_cooltime_effect_anim = transform.GetChild(1).GetChild(2).GetComponent<Animator>();
        skill_03_cooltime_effect_anim = transform.GetChild(2).GetChild(2).GetComponent<Animator>();
    }

    #region Skills

    public void Skill_01()
    {
        audio_skill_use.Play();

        HPbarManager.GetHPbarmanager.SetHP(HPbarManager.GetHPbarmanager.GetHP() + 0.2f);
        GoldManager.getGoldmanager.SetGold(GoldManager.getGoldmanager.GetGold() - 100);
        StartCoroutine(Skill_01_CoolTime());
        StartCoroutine(Skill_CoolTimeBar(skill_01_effecttime_image, skill_01_EFFECTTIME));
    }

    public void Skill_02()
    {
        audio_skill_use.Play();

        VirusManager.GetVirusmanager.SetVirusReverse(true);
        GoldManager.getGoldmanager.SetGold(GoldManager.getGoldmanager.GetGold() - 100);
        StartCoroutine(Skill_02_EffectTime());
        StartCoroutine(Skill_02_CoolTime());
        StartCoroutine(Skill_CoolTimeBar(skill_02_effecttime_image, skill_02_EFFECTTIME));
    }

    public void Skill_03()
    {
        audio_skill_use.Play();

        float origin_var = SpeedManager.Speedmanager.GetSpeed();

        SpeedManager.Speedmanager.SetSpeed(SpeedManager.Speedmanager.GetSpeed() + 5f);
        GoldManager.getGoldmanager.SetGold(GoldManager.getGoldmanager.GetGold() - 100);
        StartCoroutine(Skill_03_EffectTime(origin_var));
        StartCoroutine(Skill_03_CoolTime());
        StartCoroutine(Skill_CoolTimeBar(skill_03_effecttime_image, skill_03_EFFECTTIME));

    }

    #endregion

    #region CoolTime

    private IEnumerator Skill_01_CoolTime()
    {
        skill_01_button.interactable = false;
        skill_01_cooltime_text.gameObject.SetActive(true);
        float cooltime = 0f;

        while (skill_01_time <= 1f)
        {
            cooltime += Time.deltaTime * 1.5f;
            skill_01_time += Time.deltaTime / skill_01_COOLTIME * 1.5f;
            skill_01_image.GetComponent<Image>().fillAmount = skill_01_time;
            skill_01_cooltime_text.text = ((int)skill_01_COOLTIME - (int)cooltime).ToString();
            if ((skill_01_COOLTIME - cooltime) < 0.1f)
                skill_01_cooltime_text.gameObject.SetActive(false);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        audio_skill_cooltime_end.Play();
        skill_01_time = 0;
        skill_01_button.interactable = true;
        StartCoroutine(Skill_CoolTime_End_Effect(skill_01_button, skill_01_cooltime_effect_anim));
    }

    private IEnumerator Skill_02_CoolTime()
    {
        skill_02_button.interactable = false;
        skill_02_cooltime_text.gameObject.SetActive(true);
        float cooltime = 0f;

        while (skill_02_time <= 1f)
        {
            cooltime += Time.deltaTime * 1.5f;
            skill_02_time += Time.deltaTime / skill_02_COOLTIME * 1.5f;
            skill_02_image.GetComponent<Image>().fillAmount = skill_02_time;
            skill_02_cooltime_text.text = ((int)skill_02_COOLTIME - (int)cooltime).ToString();
            if ((skill_02_COOLTIME - cooltime) < 0.1f)
                skill_02_cooltime_text.gameObject.SetActive(false);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        audio_skill_cooltime_end.Play();
        skill_02_time = 0;
        skill_02_button.interactable = true;
        StartCoroutine(Skill_CoolTime_End_Effect(skill_02_button, skill_02_cooltime_effect_anim));
    }

    private IEnumerator Skill_03_CoolTime()
    {
        skill_03_button.interactable = false;
        skill_03_cooltime_text.gameObject.SetActive(true);
        float cooltime = 0f;

        while (skill_03_time <= 1f)
        {
            cooltime += Time.deltaTime * 1.5f;
            skill_03_time += Time.deltaTime / skill_03_COOLTIME * 1.5f;
            skill_03_image.GetComponent<Image>().fillAmount = skill_03_time;
            skill_03_cooltime_text.text = ((int)skill_03_COOLTIME - (int)cooltime).ToString();
            if ((skill_03_COOLTIME - cooltime) < 0.1f)
                skill_03_cooltime_text.gameObject.SetActive(false);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        audio_skill_cooltime_end.Play();
        skill_03_time = 0;
        skill_03_button.interactable = true;
        StartCoroutine(Skill_CoolTime_End_Effect(skill_03_button, skill_03_cooltime_effect_anim));
    }

    #endregion

    #region EffectTime

    private IEnumerator Skill_01_EffectTime()
    {
        yield return new WaitForSeconds(skill_01_EFFECTTIME);
    }

    private IEnumerator Skill_02_EffectTime()
    {
        yield return new WaitForSeconds(skill_02_EFFECTTIME);

        VirusManager.GetVirusmanager.SetVirusReverse(false);
    }

    private IEnumerator Skill_03_EffectTime(float _f)
    {
        yield return new WaitForSeconds(skill_03_EFFECTTIME);

        SpeedManager.Speedmanager.SetSpeed(_f);
    }

    #endregion

    private IEnumerator Skill_CoolTime_End_Effect(Button _b, Animator _a)
    {
        _a.gameObject.SetActive(true);
        float x = 300f;
        float y = 300f;
        Vector2 origin_var = _b.GetComponent<RectTransform>().sizeDelta;
        _b.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);

        while (_b.GetComponent<RectTransform>().sizeDelta.x > origin_var.x &&
            _b.GetComponent<RectTransform>().sizeDelta.y > origin_var.y)
        {
            x -= 10f;
            y -= 10f;
            _b.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
            if (_a.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
                _a.gameObject.SetActive(false);

            yield return new WaitForSeconds(0.02f);
        }
    }

    private IEnumerator Skill_CoolTimeBar(Image _i, float _f)
    {
        float _f_half = _f * 0.3f;
        float time = 0f;
        bool flag = false;

        _i.gameObject.SetActive(true);
        yield return new WaitForSeconds(_f - _f_half);

        while (time < _f_half)
        {
            time += 0.2f;
            flag = !flag;
            if (!flag)
                _i.gameObject.SetActive(false);
            else
                _i.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.2f);
        }

        _i.gameObject.SetActive(false);
    }
}
