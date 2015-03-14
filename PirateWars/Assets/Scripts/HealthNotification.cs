using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthNotification : MonoBehaviour {

	private float stopTime;
	private bool output;
	private Text t;
	private float hp;

	// Use this for initialization
	void Start () {
		output = false;
		t = GetComponent<Text>();
		hp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (output && Time.time > stopTime)
		{
			t.text = "";
			output = false;
			hp = 0;
		}
		else if(output)
			t.text = "Health + " + hp + " HP";
	}
	
	public void printMessage(float value, float time)
	{
		hp += value;
		output = true;
		stopTime = Time.time + time;
	}
}
