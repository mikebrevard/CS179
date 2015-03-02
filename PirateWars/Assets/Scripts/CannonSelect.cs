using UnityEngine;
using System.Collections;


public class CannonSelect : MonoBehaviour {

	public GameObject weapon1;
	public GameObject weapon2;

	// Use this for initialization
	void Start () {
		weapon2.SetActive (false);
		weapon1.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) 
		{
			weapon2.SetActive (false);
			weapon1.SetActive (true);
		}
		if (Input.GetKeyDown ("2")) 
		{
			weapon1.SetActive (false);
			weapon2.SetActive (true);
		}

	}
}
