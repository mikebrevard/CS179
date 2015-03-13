using UnityEngine;
using System.Collections;


public class CannonSelect : MonoBehaviour {

	public GameObject[] weapons;
	private bool spread_bough = false;
	private bool sniper_bough = false;
	private bool burst_bough = false;
	private bool auto_bough = false;
	void SelectCannon(int index)
	{
		foreach (GameObject n in weapons) 
		{
			n.SetActive (false);
		}
		weapons[index].SetActive (true);
	}

	// Use this for initialization
	void Start () {
		SelectCannon (0);
	}
	public void setspread()
	{
		spread_bough = true;
	}
	public void setsniper()
	{
		sniper_bough = true;
	}
	public void setburs()
	{
		burst_bough = true;
	}
	public void setauto()
	{
		auto_bough = true;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) 
		{
			SelectCannon (0);
		}
		if (Input.GetKeyDown ("2")) 
		{
			SelectCannon (1);
		}
		if (Input.GetKeyDown ("3")) 
		{
			SelectCannon (2);
		}
		if (Input.GetKeyDown ("4")) 
		{
			SelectCannon (3);
		}
		if (Input.GetKeyDown ("5")) 
		{
			SelectCannon (4);
		}
		if (Input.GetKeyDown ("6")) 
		{
			SelectCannon (5);
		}
	}
}
