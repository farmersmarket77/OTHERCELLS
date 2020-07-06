using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager Speedmanager;

    [SerializeField]
    private float speed;

    public float GetSpeed() { return speed; }
    public void SetSpeed(float f) { speed = f; }

    private void Awake()
    {
        if (Speedmanager == null)
            Speedmanager = this;
        else if (Speedmanager != this)
            Destroy(gameObject);

        speed = 5;
    }
}
