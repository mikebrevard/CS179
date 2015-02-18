using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour 
{
	public Rect windowRect = new Rect(Screen.width / 2, Screen.height / 2, 200, 200);
	int step = 0;
	// Use this for initialization
	int timer = 0;
	bool left = false;
	bool right = false;
	void Start () 
	{
	}
	void OnGUI() 
	{
		if (step == 0)
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "Press W to go forward", GUILayout.Width(300));

		}
		else if (step == 2) 
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "Press S to go backward", GUILayout.Width(300));
		}
		else if (step == 4) 
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "Press A to turn left", GUILayout.Width(300));
		}
		else if (step == 6) 
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "Press D to turn right", GUILayout.Width(300));
		}
		else if (step == 8) 
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "Press Q to look left,\nthen click to shot", GUILayout.Width(300));
		}
		else if (step == 10) 
		{
			Time.timeScale = 0;
			windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "Press E to look right,\nthen click to shot", GUILayout.Width(300));
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
		if (left == true && Input.GetMouseButtonDown(0)) 
		{
			step++;
		}
		if (right == true && Input.GetMouseButtonDown(0)) 
		{
			Application.LoadLevel("Game Main");
		}
		if (timer == 50) 
		{
			timer = 0;
			step++;
		}
	}
	void DoMyWindow(int windowID) 
	{
		if (GUILayout.Button ("Continue"))
		{
			Time.timeScale = 1;
			step++;
		}
	}
}
