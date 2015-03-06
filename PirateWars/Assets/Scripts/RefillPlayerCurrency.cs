using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RefillPlayerCurrency : MonoBehaviour {

	public Text AddCurrency;
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

			Destroy (gameObject);

			//startTime = (0.0f + Time.time);
			//stopTime = (2.0f + Time.time);

			//StartCoroutine(Message(2));
			//Message(2.0f);
		}
	}
	/*
	void Message (float delay) {
		
		AddCurrency = GameObject.FindGameObjectWithTag("AddCurrencyGUI").GetComponent<Text>();

		AddCurrency.text = "+ $100";
		if(Time.time > startTime)
		{
			AddCurrency.enabled = true;
			print ("Enter");
		}
		if(Time.time > stopTime)
		{
			print ("Ended");
			AddCurrency.text = "";
			AddCurrency.enabled = false;
			return;
		}
	}*/
}
