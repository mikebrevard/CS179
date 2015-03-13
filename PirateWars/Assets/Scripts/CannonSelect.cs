using UnityEngine;
using System.Collections;


public class CannonSelect : MonoBehaviour {

	public GameObject[] weapons;

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

	// Update is called once per frame
	void Update () 
	{
		PlayerHealth player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth> ();
		Pausedmenu whichcanon = GameObject.FindGameObjectWithTag ("Pause").GetComponent<Pausedmenu> ();
		if (Input.GetKeyDown ("1")) 
		{
			SelectCannon (0);
		}
		if (Input.GetKeyDown ("2")) 
		{
			if (whichcanon.getspread())
			{
				SelectCannon (1);
			}
		}
		if (Input.GetKeyDown ("3")) 
		{
			if (whichcanon.getsniper())
			{
				SelectCannon (2);
			}
		}
		if (Input.GetKeyDown ("4")) 
		{
			if (whichcanon.getburst())
			{
				SelectCannon (3);
			}
		}
		if (Input.GetKeyDown ("5")) 
		{
			if (whichcanon.getauto())
			{
				SelectCannon (4);
			}
		}
		if (Input.GetKeyDown ("6")) 
		{
			if (whichcanon.getmini())
			{
				SelectCannon (5);
			}
		}
	}
}
