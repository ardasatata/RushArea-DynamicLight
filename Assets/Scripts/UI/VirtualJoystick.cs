using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    private Image BgImage;
    private Image JoystickImage;
    public Vector2 inputVector;

    void Start() {
        BgImage = GetComponent<Image>();
        JoystickImage = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BgImage.rectTransform
                                                                    , eventData.position
                                                                    , eventData.pressEventCamera
                                                                    , out pos))
        {
            pos.x = (pos.x / BgImage.rectTransform.sizeDelta.x);

            inputVector = new Vector2(pos.x*2, 0);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;


            // Move joystick
            JoystickImage.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * (BgImage.rectTransform.sizeDelta.x / 3),0,0);

        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        JoystickImage.color = new Color(1,1,1,1);
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        JoystickImage.color = new Color(1, 1, 1, 150/255.0f);
        inputVector = Vector2.zero;
        JoystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }


    public bool MovetoRight() {
        return inputVector.x > 0;
    }

    public bool Moving()
    {
        return inputVector.x!=0;
    }

}
