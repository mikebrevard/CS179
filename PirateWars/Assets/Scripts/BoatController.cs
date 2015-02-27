using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour 
{
	public float speed;
	public float rotationSpeed;
	public GameObject water;
	public GameObject water_left;
	public GameObject water_right;
	void Update()
	{
		if (Time.timeScale == 1)
		{
			Vector3 speed_of_boat = Vector3.forward * Input.GetAxis ("Vertical") * speed;
			rigidbody.AddRelativeForce (speed_of_boat);
			transform.Rotate (Vector3.up * Input.GetAxis ("Horizontal") * rotationSpeed);
			if (rigidbody.velocity.magnitude > 8)
			{
				Instantiate(water, water_left.transform.position, water_left.transform.rotation);
				Instantiate(water, water_right.transform.position, water_right.transform.rotation);
			}
		}
	}
}
