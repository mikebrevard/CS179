using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BurstFire : MonoBehaviour {
	
	public GameObject cannonball;
	public GameObject flash;
	public GameObject muzzle;
	public float rateOfFire;
	float fireDelay;
	float timerGUI;
	public float speed;

	public float x;
	public float y;
	
	void Update()
	{
		
		if (Input.GetButton ("Fire1") && Time.time > fireDelay) 
		{
			GameObject ammoCounter = GameObject.FindGameObjectWithTag ("Ammo");
			Ammo ammo = ammoCounter.GetComponent<Ammo>();
			
			if(ammo.getAmmo() > 2)
			{
				fireDelay = Time.time + rateOfFire;
				timerGUI = rateOfFire;
				GameObject clone = (GameObject)Instantiate (cannonball, transform.position, transform.rotation);
				GameObject clone2 = (GameObject)Instantiate (cannonball, transform.position, transform.rotation);
				GameObject clone3 = (GameObject)Instantiate (cannonball, transform.position, transform.rotation);
				clone.rigidbody.velocity = transform.TransformDirection (new Vector3(0,0,.8f * speed));
				clone2.rigidbody.velocity = transform.TransformDirection (new Vector3(0,0,speed));
				clone3.rigidbody.velocity = transform.TransformDirection (new Vector3(0,0,1.2f * speed));
				Instantiate(flash, muzzle.transform.position, muzzle.transform.rotation);
				
				//Physics.IgnoreCollision (clone.collider, transform.root.collider);
				audio.Play();
				ammo.shotFired();
				ammo.shotFired();
				ammo.shotFired();
			}
		}
		timerGUI -= Time.deltaTime;
		if (timerGUI <= 0)
			timerGUI = 0;
	}
	void OnGUI()
	{
		GUI.Box (new Rect (x, y, 50, 20), "" + timerGUI.ToString ("0"));
	}
}
