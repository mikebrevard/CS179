using UnityEngine;
using System.Collections;


public class CannonSelect : MonoBehaviour {

	public GameObject[] weapons;

	void SelectCannon(int index)
	{
		foreach (GameObject n in weapons) {
			n.SetActive (false);
				}
		weapons[index].SetActive (true);
	}

	// Use this for initialization
	void Start () {
		SelectCannon (0);
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
