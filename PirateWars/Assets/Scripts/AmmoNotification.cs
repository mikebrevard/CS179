using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoNotification : MonoBehaviour {


	//private float startTime;
	private float stopTime;
	private bool output;
	private Text t;
	// Use this for initialization
	void Start () {
		output = false;
		t = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (output && Time.time > stopTime)
		{
			t.text = "";
			output = false;
		}
	}

	public void printMessage(float value, float time)
	{
		t.text = "+ " + value + "Cannonballs";
		output = true;
		stopTime = Time.time + time;
	}
}
