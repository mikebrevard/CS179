using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Currency : MonoBehaviour {

	private Text currencyGUI;
	public int money = 0;

	// Use this for initialization
	void Awake(){
		//DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag ("CurrencyGUI"))
		{
			currencyGUI = GameObject.FindGameObjectWithTag ("CurrencyGUI").GetComponent<Text> ();
			currencyGUI.text = "Money: $" + money;
		}
	}

	public void addCurrency(int m)
	{
		money += m;
	}
	public int checkCurrency()
	{
		return money;
	}
	public void spendCurrency(int m)
	{
		money -= m;
	}
}