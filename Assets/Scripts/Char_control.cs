using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_control : MonoBehaviour {

    public float moveSpeed = 6;

    Rigidbody myRigidbody;
    Camera viewCamera;
    Vector3 velocity;

    public Vector3 _mousePos;

    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }
	
	void Update () {
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.z));

        transform.LookAt(mousePos + Vector3.right * transform.position.x);

        //print(mousePos);
        _mousePos = mousePos;

        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0).normalized * moveSpeed;
    }

    void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }

}
