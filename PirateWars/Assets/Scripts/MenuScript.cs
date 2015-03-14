using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public void OnClickPlay(){
		Application.LoadLevel("Game Main");
	}
	public void OnClickTutorial()
	{
		Application.LoadLevel("Tutorial");
	}
	public void OnClickQuit()
	{
		Application.Quit();
	}
	void OnMouseOver () 
	{
		Screen.showCursor = false;
	}
}