using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIAnimMaster : MonoBehaviour
{
    private UIAnimMaster() { }
    public static UIAnimMaster UIanim_master = null;

    private void Awake()
    {
        if (UIanim_master == null)
            UIanim_master = this;
        else if (UIanim_master != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator ButtonTapAnim(GameObject _b)
    {
        _b.GetComponent<Button>().interactable = false;
        float ori_x = _b.GetComponent<RectTransform>().localScale.x;
        float ori_y = _b.GetComponent<RectTransform>().localScale.y;
        float x = _b.GetComponent<RectTransform>().localScale.x;
        float y = _b.GetComponent<RectTransform>().localScale.y;

        _b.GetComponent<RectTransform>().localScale = new Vector2(x, y);

        while (x < ori_x + 0.05f)
        {
            x += 0.015f;
            y += 0.015f;

            _b.GetComponent<RectTransform>().localScale = new Vector2(x, y);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        while (x > ori_x)
        {
            x -= 0.015f;
            y -= 0.015f;

            _b.GetComponent<RectTransform>().localScale = new Vector2(x, y);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        _b.GetComponent<Button>().interactable = true;
        _b.GetComponent<RectTransform>().localScale = new Vector2(ori_x, ori_y);
    }
    public IEnumerator ButtonTapAnim(GameObject _b, string _scene)
    {
        _b.GetComponent<Button>().interactable = false;
        float ori_x = _b.GetComponent<RectTransform>().localScale.x;
        float ori_y = _b.GetComponent<RectTransform>().localScale.y;
        float x = _b.GetComponent<RectTransform>().localScale.x;
        float y = _b.GetComponent<RectTransform>().localScale.y;

        _b.GetComponent<RectTransform>().localScale = new Vector2(x, y);

        while (x < ori_x + 0.05f)
        {
            x += 0.015f;
            y += 0.015f;

            _b.GetComponent<RectTransform>().localScale = new Vector2(x, y);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        while (x > ori_x)
        {
            x -= 0.015f;
            y -= 0.015f;

            _b.GetComponent<RectTransform>().localScale = new Vector2(x, y);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        _b.GetComponent<Button>().interactable = true;
        _b.GetComponent<RectTransform>().localScale = new Vector2(ori_x, ori_y);
        SceneManager.LoadScene(_scene);
    }
}
