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
	private bool bought_mini = false;
	Rect rect = new Rect(Screen.width / 2 - 100, Screen.height / 2 , 200, 300);
	
	// Use this for initialization
	void Start () 
	{
		Screen.showCursor = false;
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
			Screen.showCursor = false;
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
			Screen.showCursor = false;
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
			if(gold.checkCurrency() > 99)
			{
				gold.spendCurrency(100);
				setspread();
			}
			else
			{
				enoughgold = false;
			}
		}
		if (GUILayout.Button ("Sniper cannon 200")) 
		{
			GameObject currency = GameObject.FindGameObjectWithTag ("Currency");
			Currency gold = currency.GetComponent<Currency>();
			if(gold.checkCurrency() > 199)
			{
				gold.spendCurrency(200);
				setsniper();
			}
			else
			{
				enoughgold = false;
			}
		}
		if (GUILayout.Button ("Burst cannon 400")) 
		{
			GameObject currency = GameObject.FindGameObjectWithTag ("Currency");
			Currency gold = currency.GetComponent<Currency>();
			if(gold.checkCurrency() > 399)
			{
				gold.spendCurrency(400);
				setburst();
			}
			else
			{
				enoughgold = false;
			}
		}
		if (GUILayout.Button ("Auto cannon 800")) 
		{
			GameObject currency = GameObject.FindGameObjectWithTag ("Currency");
			Currency gold = currency.GetComponent<Currency>();
			if(gold.checkCurrency() > 799)
			{
				gold.spendCurrency(800);
				setauto();
			}
			else
			{
				enoughgold = false;
			}
		}
		if (GUILayout.Button ("Mini cannon 2000")) 
		{
			GameObject currency = GameObject.FindGameObjectWithTag ("Currency");
			Currency gold = currency.GetComponent<Currency>();
			if(gold.checkCurrency() > 1999)
			{
				gold.spendCurrency(2000);
				setmini();
			}
			else
			{
				enoughgold = false;
			}
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
	
	public void setspread()
	{
		bought_spread = true;
	}
	public void setsniper()
	{
		bought_sniper = true;
	}
	public void setburst()
	{
		bought_burst = true;
	}
	public void setauto()
	{
		bought_auto = true;
	}
	public void setmini()
	{
		bought_mini = true;
	}
	
	public bool getspread()
	{
		return bought_spread;
	}
	public bool getsniper()
	{
		return bought_sniper;
	}
	public bool getburst()
	{
		return bought_burst;
	}
	public bool getauto()
	{
		return bought_auto;
	}
	public bool getmini()
	{
		return bought_mini;
	}
}
