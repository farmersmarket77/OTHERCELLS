using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickMoveController : MonoBehaviour
{
    private JoystickMoveController() { }
    public static JoystickMoveController Joystick_MC;

    public JoystickMove joystick;

    private float move_speed;
    private Vector3 move_vec;
    private Transform tr;

    private void Start()
    {
        Joystick_MC = this;
        move_speed = SpeedManager.Speedmanager.GetSpeed();
        tr = transform;
        move_vec = Vector3.zero;
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void HandleInput()
    {
        move_vec = poolInput();
    }

    public Vector3 poolInput()
    {
        float h = joystick.GetHorizontalValue();
        float v = joystick.GetVerticalValue();
        Vector3 move_dir = new Vector3(-h, -v, 0).normalized;

        return move_dir;
    }

    public void Move()
    {
        move_speed = SpeedManager.Speedmanager.GetSpeed();
        tr.Translate(move_vec * move_speed * Time.deltaTime);
    }
}
