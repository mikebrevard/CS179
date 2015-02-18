using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ammo : MonoBehaviour {

	public int ammo = 25;
	public int maxAmmo = 25;
	public Text ammoGUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ammoGUI.text = "Cannonballs: " + ammo + "/" + maxAmmo;
	}

	public int getAmmo()
	{
		return ammo;
	}

	public void shotFired()
	{
		if(ammo > 0)
			ammo -= 1;
	}
}
