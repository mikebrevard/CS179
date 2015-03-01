using UnityEngine;
using System.Collections;

public class RefillPlayerCurrency : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "PlayerShip")
		{
			GameObject currency = GameObject.FindGameObjectWithTag ("Currency");
			Currency c = currency.GetComponent<Currency>();
			c.addCurrency(100);

			Destroy (gameObject);
		}
	}
}
