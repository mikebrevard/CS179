using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RefillPlayerHealth : MonoBehaviour {

	public Text AddHealth;

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

			Destroy (gameObject);

			//Message ();
		}
	}
	/*
	void Message () {
		
		AddHealth = GameObject.FindGameObjectWithTag("AddHealthGUI").GetComponent<Text>();
		if(Time.time < stopTime)
			AddHealth.text = "+ 25 HP";
		else
		{
			AddHealth.text = "";
		}
	}*/
}

