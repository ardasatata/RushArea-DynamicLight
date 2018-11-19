using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public bool buttonDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonDown = false;
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
