using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour 
{
	public Rect windowRect = new Rect(Screen.width / 2, Screen.height / 2, 100, 100);
	int step = 0;
	// Use this for initialization
	int timer = 0;
	bool left = false;
	bool right = false;
	int shot_count = 0;
	void Start () 
	{
	}
	void OnGUI() 
	{
		if (step == 0)
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "", GUILayout.Width(200));

		}
		else if (step == 2) 
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "", GUILayout.Width(200));
		}
		else if (step == 4) 
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "", GUILayout.Width(200));
		}
		else if (step == 6) 
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "", GUILayout.Width(200));
		}
		else if (step == 8) 
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "", GUILayout.Width(200));
		}
		else if (step == 10) 
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "", GUILayout.Width(200));
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if ((step == 1 && Input.GetKey(KeyCode.W)) || (step == 3 && Input.GetKey(KeyCode.S)) || (step == 5 && Input.GetKey(KeyCode.A)) || (step == 7 && Input.GetKey(KeyCode.D))) 
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
		if (timer == 150 || shot_count == 3) 
		{
			timer = 0;
			step++;
			shot_count = 0;
			if (step == 12)
			{
				Application.LoadLevel("Game Main");
			}
		}
	}
	void DoMyWindow(int windowID) 
	{
		if (step == 0)
		{
			GUILayout.TextArea("Press W to go forward", 100);
		}
		else if (step == 2) 
		{
			GUILayout.TextArea("Press S to go backward", 100);
		}
		else if (step == 4) 
		{
			GUILayout.TextArea("Press A to turn left", 100);
		}
		else if (step == 6) 
		{
			GUILayout.TextArea("Press D to turn right", 100);
		}
		else if (step == 8) 
		{
			GUILayout.TextArea("Press Q to look left,\nthen click to shot, shot 3 times", 100);
		}
		else if (step == 10) 
		{
			GUILayout.TextArea("Press E to look right,\nthen click to shot, shot 3 times", 100);
		}
		if (GUILayout.Button ("Continue"))
		{
			Time.timeScale = 1;
			step++;
		}
	}
}