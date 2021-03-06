﻿using UnityEngine;
using System.Collections;

public class BoatController2 : MonoBehaviour {
	
	float speed = 0f;
	public float accel;
	public float rotationSpeed;
	public float minSpeed;
	public float maxSpeed;
	public float drag;

	public GameObject water;
	public GameObject water_left;
	public GameObject water_right;
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) 
		{
			speed += accel;
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			speed -= accel;
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			if (speed >= 1 || speed <= -1) {
				transform.Rotate (Vector3.down * rotationSpeed * Time.deltaTime * speed);
			}
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			if(speed >= 1 || speed <= -1)
			{
				transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime * speed);
			}
		}
		if (speed > 0) 
		{
			speed -= drag;
		}
		else if(speed < 0)
		{
			speed += drag;
		}
		
		if (speed > maxSpeed)
		{
			speed = maxSpeed;
		}
		if (speed < minSpeed)
		{
			speed = minSpeed;
		}
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		if (speed >= 5 || speed <= -5)
		{
			Instantiate(water, water_left.transform.position, water_left.transform.rotation);
			Instantiate(water, water_right.transform.position, water_right.transform.rotation);
		}
	}
}