using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private Text scoreGUI;
	int score = 0;
	private Text highscoreGUI;

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
		if(score > PlayerPrefs.GetInt("highscore")){
			PlayerPrefs.SetInt("highscore", score);
		}
		if(GameObject.FindGameObjectWithTag ("highscoreGUI"))
		{
			highscoreGUI = GameObject.FindGameObjectWithTag ("highscoreGUI").GetComponent<Text> ();
			if(PlayerPrefs.HasKey ("highscore"))
			{
				highscoreGUI.text = "High Score: " + PlayerPrefs.GetInt ("highscore");
			}
			else
			{
				highscoreGUI.text = "High Score : 0";
			}
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
