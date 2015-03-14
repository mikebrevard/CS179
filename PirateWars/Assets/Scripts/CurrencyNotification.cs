using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrencyNotification : MonoBehaviour {

	//private float startTime;
	private float stopTime;
	private bool output;
	private Text t;
	private float money;
	// Use this for initialization
	void Start () {
		output = false;
		t = GetComponent<Text>();
		money = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (output && Time.time > stopTime)
		{
			t.text = "";
			output = false;
			money = 0;
		}
		else if (output)
			t.text = "Currency + $" + money;

	}
	
	public void printMessage(float value, float time)
	{
		money += value;
		output = true;
		stopTime = Time.time + time;
	}
}
