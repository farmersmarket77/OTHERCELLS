using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusAnim : MonoBehaviour
{
    public GameObject particle_01;
    public GameObject particle_02;
    public GameObject particle_03;

    private GameObject audiomaster;
    private AudioSource audio_eat_01;
    private AudioSource audio_eat_02;

    private void Start()
    {
        audiomaster = GameObject.FindGameObjectWithTag("audiomaster");
        audio_eat_01 = audiomaster.transform.GetChild(1).GetChild(4).GetComponent<AudioSource>();
        audio_eat_02 = audiomaster.transform.GetChild(1).GetChild(5).GetComponent<AudioSource>();
    }

    public IEnumerator VirusDeadAnim()
    {
        Destroy(gameObject.GetComponent<CircleCollider2D>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        GameObject p = Instantiate(SelectParticle());
        float f = transform.localScale.x;
        int idx = Random.Range(0, 2);

        switch(idx)
        {
            case 0:
                audio_eat_01.Play();
                break;
            case 1:
                audio_eat_02.Play();
                break;
        }

        while (f > 0f)
        {
            f -= Time.deltaTime;
            transform.localScale = new Vector3(f, f, f);

            yield return new WaitForSeconds(0.02f);
        }

        Destroy(p);
        Destroy(gameObject);
    }

    private GameObject SelectParticle()
    {
        int idx = Random.Range(0, 3);

        switch (idx)
        {
            case 0:
                return particle_01;
            case 1:
                return particle_02;
            case 2:
                return particle_03;
            default:
                return null;
        }
    }
}
