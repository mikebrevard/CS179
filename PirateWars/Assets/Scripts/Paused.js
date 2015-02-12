#pragma strict

var isPause = false;
var MainMenu : Rect = Rect (Screen.width / 2, Screen.height / 2, 200, 200);
//MainMenu.center = new Vector2 (500, 500);
function Start()
{
	Screen.showCursor = true;
}
function Update () 
{
	if( Input.GetKeyDown(KeyCode.Escape))
	{
		isPause = !isPause;
		if(isPause)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
}
function OnGUI()
{
	if(isPause)
		GUI.Window(0, MainMenu, TheMainMenu, "Pause Menu");
}

function TheMainMenu () 
{
	if(GUILayout.Button("Resume"))
	{
		isPause = false;
		Time.timeScale = 1;
	}
	if(GUILayout.Button("Main Menu"))
	{
		Application.LoadLevel("Game Start");
	}
	if(GUILayout.Button("Restart") || Input.GetKeyDown(KeyCode.R))
	{
		isPause = false;
		Time.timeScale = 1;
		Application.LoadLevel("Game Main");
	}
	if(GUILayout.Button("Quit"))
	{
		Application.Quit();
	}
}