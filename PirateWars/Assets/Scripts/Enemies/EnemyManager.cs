using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
	//public PlayerHealth playerHealth;       // Reference to the player's heatlh.
	public Transform enemy;                // The enemy prefab to be spawned.
	public float spawnTime;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public float enemyLimit;			// The number of enemies allowed on the map at a given time
	private System.Collections.Generic.List<GameObject> enemies;			// The enemies currently on the map
	private float enemyIndex;
	
	
	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		enemies = new System.Collections.Generic.List<GameObject>();

		//start with zero clones
		enemyIndex = 0f; 
	}
	
	
	void Spawn ()
	{
		//print ("Current Number of Enemies" + enemyIndex + "\tand limit " + enemyLimit);
		// If the total number of enemies is reached
		if(enemyIndex == enemyLimit)
		{
			// ... exit the function.
			return;
		}

		//add enemy to list
		//enemies.Add (enemy);
		enemyIndex++;

		// Find a random index between zero and one less than the number of spawn points.
		// TODO: force not to land on same spawn point
		int spawnPointIndex = Random.Range (0, spawnPoints.Length - 1);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Transform clone  = (Transform) Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		clone.tag = "Enemy";
	}

	public void EnemyDied ()
	{
		enemyIndex--;
	}
}
