using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour 
{
	Rect windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 , 200, 300);
	int step = 0;
	// Use this for initialization
	int timer = 0;
	bool left = false;
	bool right = false;
	int shot_count = 0;
	void Start () 
	{
		Screen.showCursor = false;
	}
	void OnGUI() 
	{
		if (step == 0) {
			Time.timeScale = 0;
			Screen.showCursor = true;
			windowRect = GUILayout.Window (0, windowRect, DoMyWindow, "");


		} else if (step == 2) {
			Time.timeScale = 0;
			Screen.showCursor = true;
			windowRect = GUILayout.Window (0, windowRect, DoMyWindow, "");
		} else if (step == 4) {
			Time.timeScale = 0;
			Screen.showCursor = true;
			windowRect = GUILayout.Window (0, windowRect, DoMyWindow, "");
		} else if (step == 6) {
			Time.timeScale = 0;
			Screen.showCursor = true;
			windowRect = GUILayout.Window (0, windowRect, DoMyWindow, "");
		} else if (step == 8) {
			Time.timeScale = 0;
			Screen.showCursor = true;
			windowRect = GUILayout.Window (0, windowRect, DoMyWindow, "");
		} else if (step == 10) {
			Time.timeScale = 0;
			Screen.showCursor = true;
			windowRect = GUILayout.Window (0, windowRect, DoMyWindow, "");
		} else if (step == 12) 
		{
			Time.timeScale = 0;
			Screen.showCursor = true;
			windowRect = GUILayout.Window (0, windowRect, DoMyWindow, "");
		}
		else if (step == 14) 
		{
			Time.timeScale = 0;
			Screen.showCursor = true;
			windowRect = GUILayout.Window (0, windowRect, DoMyWindow, "");
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if ((step == 1 && Input.GetKey(KeyCode.W)) || (step == 3 && Input.GetKey(KeyCode.S)) || (step == 5 && Input.GetKey(KeyCode.A)&& Input.GetKey(KeyCode.W)) || (step == 7 && Input.GetKey(KeyCode.D)&& Input.GetKey(KeyCode.W))) 
		{
			timer++;
		}
		if (step == 9 && Input.GetKey(KeyCode.Q))
		{
			left = true;
		}
		if (step == 11 && Input.GetKey(KeyCode.E))
		{
			right = true;
		}
		if ((left == true || right == true)&& Input.GetMouseButtonDown(0))
		{
			shot_count++;
		}
		if (step == 13 && Input.GetKey(KeyCode.Space))
		{
			step++;
		}
		if ((step == 14 ||step == 15) && Input.GetKey (KeyCode.Escape)) 
		{
			Application.LoadLevel("Game Main");
		}
		if (timer == 150 || shot_count == 4) 
		{
			timer = 0;
			step++;
			shot_count = 0;
		}
	}
	IEnumerator Example() {
		yield return new WaitForSeconds(3);
	}
	void DoMyWindow(int windowID) 
	{
		if (step == 0) {
			GUILayout.TextArea ("Press W to go forward");
		} else if (step == 2) {
			GUILayout.TextArea ("Press S to go backward", 100);
		} else if (step == 4) {
			GUILayout.TextArea ("Go forward and press A to turn left", 100);
		} else if (step == 6) {
			GUILayout.TextArea ("Go forward and press D to turn right", 100);
		} else if (step == 8) {
			GUILayout.TextArea ("Press Q to look left,\nthen click to shot, shot 3 times", 100);
		} else if (step == 10) {
			GUILayout.TextArea ("Press E to look right,\nthen click to shot, shot 3 times", 100);
		} else if (step == 12) {
			GUILayout.TextArea ("Press space to go to third person view", 100);
		} else if (step == 14) {
			GUILayout.TextArea ("Press Esc to continue to main game, or hit Continue to play in this map", 100);
		}
		if (GUILayout.Button ("Continue"))
		{
			Time.timeScale = 1;
			step++;
			Screen.showCursor = false;
		}
	}
}