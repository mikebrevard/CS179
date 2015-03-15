using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cannonscript : MonoBehaviour 
{
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

			if(ammo.getAmmo() > 0)
			{
				fireDelay = Time.time + rateOfFire;
				timerGUI = rateOfFire;
				GameObject clone = (GameObject)Instantiate (cannonball, transform.position, transform.rotation);
				clone.rigidbody.velocity = transform.TransformDirection (new Vector3(0,0,speed));
				Instantiate(flash, muzzle.transform.position, muzzle.transform.rotation);

				//Physics.IgnoreCollision (clone.collider, transform.root.collider);
				audio.Play();
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
