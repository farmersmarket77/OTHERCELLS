using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarManager : MonoBehaviour
{
    //private HPbarManager() { }
    public static HPbarManager GetHPbarmanager;

    private Image HPbar;
    private float hp;

    public float GetHP() { return hp; }
    public void SetHP(float f) { hp = f; }

    private void Start()
    {
        if (GetHPbarmanager == null)
            GetHPbarmanager = this;
        else if (GetHPbarmanager != this)
            Destroy(gameObject);
        //GetHPbarmanager = this;
        HPbar = transform.GetChild(0).GetComponent<Image>();
        hp = 1f;
    }

    private void FixedUpdate()
    {
        UpdateHPbar();
    }

    private void UpdateHPbar()
    {
        if (hp < 0)
            return;
        else if (hp > 1f)
            hp = 1f;

        hp -= Time.deltaTime / 20f;
        HPbar.GetComponent<Image>().fillAmount = hp;
    }
}
