using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float sensitivity = 1f;
	private float rotationX;
	private float rotationY;

	private void Awake()
	{
		GameManager.cam = transform;
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			rotationX = 0;
			rotationY = 0;
		}

		rotationX += sensitivity * Input.GetAxis("Mouse X");
		rotationY -= sensitivity * Input.GetAxis("Mouse Y");
		rotationY = Mathf.Clamp(rotationY, -90f, 90f);
		transform.eulerAngles = new Vector3(rotationY, rotationX, 0);
	}

}