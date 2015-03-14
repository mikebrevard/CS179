using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoNotification : MonoBehaviour {


	//private float startTime;
	private float stopTime;
	private bool output;
	private Text t;
	private float cannonballs;
	// Use this for initialization
	void Start () {
		output = false;
		t = GetComponent<Text>();
		cannonballs = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (output && Time.time > stopTime)
		{
			t.text = "";
			output = false;
			cannonballs = 0;
		}
		else if (output)
			t.text = "Cannonballs + " + cannonballs;
	}

	public void printMessage(float value, float time)
	{
		cannonballs += value;
		output = true;
		stopTime = Time.time + time;
	}
}
