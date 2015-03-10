using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour {

	public GameObject cannonball;
	public GameObject flash;
	public GameObject muzzle;
	public float rateOfFire;
	float fireDelay;
	public float speed;
	
	void Update()
	{
		
		if (Input.GetButton ("Fire1") && Time.time > fireDelay) 
		{
			GameObject ammoCounter = GameObject.FindGameObjectWithTag ("Ammo");
			Ammo ammo = ammoCounter.GetComponent<Ammo>();
			
			if(ammo.getAmmo() > 0)
			{
				fireDelay = Time.time + rateOfFire;
				GameObject clone = (GameObject)Instantiate (cannonball, transform.position, transform.rotation);
				clone.rigidbody.velocity = transform.TransformDirection (new Vector3(0,0,speed));
				Instantiate(flash, muzzle.transform.position, muzzle.transform.rotation);
				
				//Physics.IgnoreCollision (clone.collider, transform.root.collider);
				audio.Play();
				ammo.shotFired();
			}
		}
	}
}
