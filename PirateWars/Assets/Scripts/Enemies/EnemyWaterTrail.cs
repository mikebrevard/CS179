using UnityEngine;
using System.Collections;

public class EnemyWaterTrail : MonoBehaviour {
	public GameObject water;
	public GameObject water_left;
	public GameObject water_right;
	void Update()
	{
		if (Time.timeScale == 1)
		{
				Instantiate(water, water_left.transform.position, water_left.transform.rotation);
				Instantiate(water, water_right.transform.position, water_right.transform.rotation);
		}
	}
}
