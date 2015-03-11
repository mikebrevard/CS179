using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RefillPlayerHealth : MonoBehaviour {

	private Text AddHealth;

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
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			PlayerHealth playerHealth = player.GetComponent <PlayerHealth> ();
			playerHealth.AddHealth(25);

			GameObject AddHealth = GameObject.FindGameObjectWithTag("AddHealthGUI");
			HealthNotification health = AddHealth.GetComponent<HealthNotification>();
			health.printMessage(100,3);

			Destroy (gameObject);

		}
	}
}

