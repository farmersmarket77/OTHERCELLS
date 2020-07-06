using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private Vector3 dir;

    private void Start()
    {
        Invoke("DestroyObject", 0.9f);
        transform.localScale = new Vector3(1f, 1f, 1f);
        Floating();
    }

    private void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }

    private void Floating()
    {
        transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
        dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
