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
			int value = Random.Range (5,10);

			GameObject ammoCounter = GameObject.FindGameObjectWithTag ("Ammo");
			Ammo ammo = ammoCounter.GetComponent<Ammo>();
			ammo.refillAmmo(value);

			GameObject AddAmmo = GameObject.FindGameObjectWithTag("AddAmmoGUI");
			AmmoNotification a = AddAmmo.GetComponent<AmmoNotification>();
			a.printMessage(value,3);

			CargoManager c = GameObject.FindGameObjectWithTag("CargoManager").GetComponent<CargoManager> ();
			c.CargoLooted();

			Destroy (gameObject);

		}
	}
}
