using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Currency : MonoBehaviour {

	public Text currencyGUI;
	int money = 0;

	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		currencyGUI.text = "$" + money;
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