using UnityEngine;
using System.Collections;

public class CargoManager : MonoBehaviour {

	public Transform cargo;                	// The cargo prefab to be spawned.
	public float spawnTime;            		// How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	private float cargoIndex;
	
	
	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		
		//start with zero clones
		cargoIndex = 0f; 
	}
	
	
	void Spawn ()
	{
		// If the total number of enemies is reached
		if(cargoIndex >= 1.0)
		{
			// ... exit the function.
			return;
		}
		
		//add enemy to list
		//enemies.Add (enemy);
		cargoIndex++;
		
		// Find a random index between zero and one less than the number of spawn points.
		// TODO: force not to land on same spawn point
		int spawnPointIndex = Random.Range (0, spawnPoints.Length - 1);
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Transform clone  = (Transform) Instantiate (cargo, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
	
	public void CargoLooted ()
	{
		cargoIndex--;
	}
}
