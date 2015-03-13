using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private Text scoreGUI;
	int score = 0;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag ("ScoreGUI"))
		{
			scoreGUI = GameObject.FindGameObjectWithTag ("ScoreGUI").GetComponent<Text> ();
			scoreGUI.text = "Score: " + score;
		}
	}

	public void addScore()
	{
		score++;
	}

	public int getScore()
	{
		return score;
	}
}
