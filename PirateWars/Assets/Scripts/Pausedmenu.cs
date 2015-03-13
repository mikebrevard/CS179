using UnityEngine;
using System.Collections;

public class Pausedmenu : MonoBehaviour {
	private bool isPause = false;
	private bool isInShop = false;
	private bool isQuit = false;
	private bool enoughgold = true;

	private bool bought_spread = false;
	private bool bought_sniper = false;
	private bool bought_burst = false;
	private bool bought_auto = false;
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
			if (!enoughgold)
			{
				GUI.Window(0, rect, not_enough_gold, "Not Enough Gold");
			}
			else if (isInShop)
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
			isInShop = false;
		}
	
		if(GUILayout.Button("+20 health for 100gold"))
		{
			GameObject currency = GameObject.FindGameObjectWithTag ("Currency");
			Currency gold = currency.GetComponent<Currency>();
			PlayerHealth player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth> ();
			if (gold.checkCurrency() > 99)
			{
				gold.spendCurrency(100);
				player.AddHealth(20);
			}
			else
			{
				enoughgold = false;
			}
		}
		if (GUILayout.Button ("spread cannon 100")) 
		{
			GameObject currency = GameObject.FindGameObjectWithTag ("Currency");
			Currency gold = currency.GetComponent<Currency>();


			CannonSelect cannon = GameObject.FindGameObjectWithTag("CannonSelect").GetComponent<CannonSelect> ();
			if(gold.checkCurrency() > 99)
			{
				gold.spendCurrency(100);
				cannon.setspread();
			}
			else
			{
				enoughgold = false;
			}
		}
		if (GUILayout.Button ("Sniper cannon 200")) 
		{
			
		}
		if (GUILayout.Button ("Burst cannon 400")) 
		{
			
		}
		if (GUILayout.Button ("auto cannon 800")) 
		{
			
		}

	}
	void not_enough_gold(int windowID)
	{
		if(GUILayout.Button("Ok"))
		{
			isInShop = true;
			enoughgold = true;
		}
	}

}
