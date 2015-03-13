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
			int value = Random.Range (10,20);

			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			PlayerHealth playerHealth = player.GetComponent <PlayerHealth> ();
			playerHealth.AddHealth(value);

			GameObject AddHealth = GameObject.FindGameObjectWithTag("AddHealthGUI");
			HealthNotification health = AddHealth.GetComponent<HealthNotification>();
			health.printMessage(value,3);

			Destroy (gameObject);

		}
	}
}

