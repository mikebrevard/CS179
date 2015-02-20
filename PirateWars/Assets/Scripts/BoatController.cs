﻿using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour 
{
	public float speed;
	public float rotationSpeed;
	void Update()
	{
		if (Time.timeScale == 1)
		{
			rigidbody.AddRelativeForce (Vector3.forward * Input.GetAxis ("Vertical") * speed);
			transform.Rotate (Vector3.up * Input.GetAxis ("Horizontal") * rotationSpeed);
		}
	}
}
