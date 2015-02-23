using UnityEngine;
using System.Collections;

public class BoatController2 : MonoBehaviour {

	float speed = 0f;
	public float accel;
	public float rotationSpeed;
	public float minSpeed;
	public float maxSpeed;
	public float drag;

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
			if (speed != 0) {
				transform.Rotate (Vector3.down * rotationSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			if(speed != 0)
			{
				transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime);
			}
		}
		speed -= drag;
		if (speed > maxSpeed)
		{
			speed = maxSpeed;
		}
		if (speed < minSpeed)
		{
			speed = minSpeed;
		}
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}
}
