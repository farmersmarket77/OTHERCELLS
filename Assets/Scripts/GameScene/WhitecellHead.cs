using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhitecellHead : MonoBehaviour
{
    [SerializeField]
    private PlayerDB player_inventory;

    public Collider2D head;
    public GameObject text;

    private void Start()
    {
        head = transform.GetComponent<Collider2D>();
        transform.GetComponent<SpriteRenderer>().sprite = player_inventory.GetPlayerCurrentClothes();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "virus")
        {
            VirusManager.GetVirusmanager.GetVirusList().Remove(collision.gameObject);
            HPbarManager.GetHPbarmanager.SetHP(HPbarManager.GetHPbarmanager.GetHP() + 0.1f);
            GoldManager.getGoldmanager.SetGold(GoldManager.getGoldmanager.GetGold() + 10);

            GameObject g = Instantiate(text);
            g.transform.SetParent(GameObject.FindGameObjectWithTag("canvas_ui").transform);
            g.GetComponent<RectTransform>().localPosition = Vector3.zero;

            StartCoroutine(collision.GetComponent<VirusAnim>().VirusDeadAnim());
        }
    }
}
