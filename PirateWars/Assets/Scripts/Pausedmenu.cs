using UnityEngine;
using System.Collections;

public class Pausedmenu : MonoBehaviour {
	private bool isPause = false;
	private bool isInShop = false;
	private bool isQuit = false;
	public Rect rect = new Rect(Screen.width / 2, Screen.height / 2 + 300, 200, 500);


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetKeyDown(KeyCode.Escape))
		{
			isPause = !isPause;
			if(isPause)
			{
				Time.timeScale = 0;
				Screen.showCursor = true;
			}
			else
			{
				Time.timeScale = 1;
				Screen.showCursor = false;
			}
		}
	}
	void OnGUI ()
	{
		if (isPause) 
		{
			if (isInShop)
			{
				GUI.Window(0, rect, ShopMenu, "Shop Menu");
			}
			else if (isQuit)
			{
				GUI.Window(0, rect, QuitMenu, "Quit?");
			}
			else
			{
				GUI.Window(0, rect, TheMainMenu, "Pause Menu");
			}

		}
	}
	void TheMainMenu (int windowID)
	{
		if(GUILayout.Button("Resume"))
		{
			isPause = false;
			Time.timeScale = 1;
		}
		if(GUILayout.Button("Shop"))
		{
			isInShop = true;
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
			isQuit = true;
		}
	}
	void QuitMenu (int windowID)
	{
		if(GUILayout.Button("Yes"))
		{
			Application.Quit();
		}
		if(GUILayout.Button("No"))
		{
			isQuit = false;
		}

	}
	void ShopMenu (int windowID)
	{
		if(GUILayout.Button("Resume game"))
		{
			isPause = false;
			Time.timeScale = 1;
		}
	
		if(GUILayout.Button("+20 maxhealth"))
		{
			GameObject currency = GameObject.FindGameObjectWithTag ("Currency");
			Currency gold = currency.GetComponent<Currency>();
			PlayerHealth player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth> ();
			if (gold.checkCurrency() > 99)
			{
				gold.addCurrency(100);
				player.MaxHealth(20);
			}
			//
			
		}
	}

}
