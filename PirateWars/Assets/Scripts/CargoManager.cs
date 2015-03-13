using UnityEngine;
using System.Collections;

public class CargoManager : MonoBehaviour {

	public Transform cargo;                	// The cargo prefab to be spawned.
	public float spawnTime;            		// How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	private bool cargoOnMap;
	private float waitTime;
	
	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		
		//start with zero clones
		cargoOnMap = false; 
	}
	
	
	void Spawn ()
	{
		// If the total number of enemies is reached
		if(cargoOnMap)
		{
			// ... exit the function.
			return;
		}

		if(Time.time > waitTime)
		{
			cargoOnMap = true;
			int spawnPointIndex = Random.Range (0, spawnPoints.Length - 1);
			Transform clone  = (Transform) Instantiate (cargo, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		}
	}
	
	public void CargoLooted ()
	{
		cargoOnMap = false;
		waitTime = Time.time + spawnTime;
	}
}
