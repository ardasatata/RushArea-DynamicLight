using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

	public GameObject Player;

	public Camera camera;

	public Transform leftLimit;
	public Transform rightLimit;
	Vector3 Offset;

	Vector3 leftOffset;
	public Vector3 rightOffset;

	Vector3 tempOffset;


	Vector3 desiredPos;

	float ytemp;

	// Use this for initialization
	void Start () {

		Offset = new Vector3 (0, 0, -10);

		desiredPos = Offset;
		ytemp = camera.transform.position.y + Offset.y;
		tempOffset = Vector3.zero;

		leftOffset = new Vector3 (Mathf.Abs (leftLimit.localPosition.x) - 0.5f, leftLimit.localPosition.y, leftLimit.localPosition.z);
		rightOffset = new Vector3 (Mathf.Abs (rightLimit.localPosition.x) + 0.5f, rightLimit.localPosition.y, rightLimit.localPosition.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (Player.gameObject.transform.position.x > rightLimit.position.x) {
			desiredPos = Player.transform.position + rightOffset;
		} 
		else if (Player.gameObject.transform.position.x < leftLimit.position.x) {
			desiredPos = Player.transform.position + leftOffset;
		}

		Vector3 smoothedPosition = Vector3.Lerp(camera.transform.position, desiredPos, .1f);
		smoothedPosition = new Vector3 (smoothedPosition.x, ytemp, smoothedPosition.z);
		camera.transform.position = smoothedPosition;

	}

}
