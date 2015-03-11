using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RefillPlayerCurrency : MonoBehaviour {

	private Text AddCurrency;
	//private float startTime;
	//private float stopTime;

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
			GameObject currency = GameObject.FindGameObjectWithTag ("Currency");
			Currency c = currency.GetComponent<Currency>();
			c.addCurrency(100);

			GameObject AddCurrency = GameObject.FindGameObjectWithTag("AddCurrencyGUI");
			CurrencyNotification cur = AddCurrency.GetComponent<CurrencyNotification>();
			cur.printMessage(100,3);

			Destroy (gameObject);

		}
	}
}
