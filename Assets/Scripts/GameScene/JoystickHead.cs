using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickHead : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bg_image;
    private Image joystick_image;
    private Vector3 input_vec;
    private Transform this_tr;
    private Vector3 this_pos;
    private Vector3 target_pos;
    private float angle;

    private void Start()
    {
        this_tr = transform.GetChild(1).transform;
        bg_image = GetComponent<Image>();
        joystick_image = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bg_image.rectTransform, ped.position,
            ped.pressEventCamera, out pos))
        {
            pos.x = pos.x / bg_image.rectTransform.sizeDelta.x;
            pos.y = pos.y / bg_image.rectTransform.sizeDelta.y;

            input_vec = new Vector3(pos.x * 2, pos.y * 2, 0);
            input_vec = (input_vec.magnitude > 1.0f) ? input_vec.normalized : input_vec;

            joystick_image.rectTransform.anchoredPosition =
                new Vector3(input_vec.x * (bg_image.rectTransform.sizeDelta.x / 3),
                input_vec.y * (bg_image.rectTransform.sizeDelta.y / 3));


            target_pos = joystick_image.transform.position;
            this_pos = this_tr.position;
            target_pos.x = target_pos.x - this_pos.x;
            target_pos.y = target_pos.y - this_pos.y;
            angle = Mathf.Atan2(target_pos.y, target_pos.x) * Mathf.Rad2Deg;
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        input_vec = Vector3.zero;
        joystick_image.rectTransform.anchoredPosition = Vector3.zero;
        
    }

    public float GetRotate()
    {
        return angle - 90f;
    }

    public Vector3 GetPosition()
    {
        return Vector3.zero;
    }
}