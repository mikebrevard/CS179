using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RefillPlayerAmmo : MonoBehaviour {

	Text AddAmmo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "PlayerLoot")
		{
			GameObject ammoCounter = GameObject.FindGameObjectWithTag ("Ammo");
			Ammo ammo = ammoCounter.GetComponent<Ammo>();
			ammo.refillAmmo(10);

			//GameObject AddAmmo = GameObject.FindGameObjectWithTag("AddAmmoGUI");
			//AmmoNotification a = AddAmmo.GetComponent<AmmoNotification>();
			//a.printMessage(10,2);

			Destroy (gameObject);

		}
	}
	/*
	void Message (float delay) {

		AddAmmo = GameObject.FindGameObjectWithTag("AddAmmoGUI").GetComponent<Text>();
		float startTime = (0.0f + Time.time);
		float stopTime = (delay + Time.time);
		if(Time.time < stopTime)
			AddAmmo.text = "+ 10 Cannonballs";
		else
		{
			AddAmmo.text = "";
			return;
		}
	}*/
}
