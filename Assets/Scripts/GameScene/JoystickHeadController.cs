using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickHeadController : MonoBehaviour
{
    public JoystickHead joystick;

    private Quaternion rotate_pos;
    private Transform tr;

    private void Start()
    {
        tr = transform;
        rotate_pos = Quaternion.identity;
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    public void HandleInput()
    {
        rotate_pos = poolInput();
    }

    public Quaternion poolInput()
    {
        float z = joystick.GetRotate();
        Quaternion rotate_dir = Quaternion.Euler(0, 0, z);

        return rotate_dir;
    }

    public void Rotate()
    {
        tr.localRotation = rotate_pos;
    }
}
