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
	private float minimumDistance = 50f;
	private Score score;
	
	
	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		enemies = new System.Collections.Generic.List<GameObject>();

		//start with zero clones
		enemyIndex = 0f; 

		//get score 
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
	}

	void Update() {
		enemyLimit = 2f + (score.getScore () / 3);
	}

	
	void Spawn ()
	{
		//print ("Current Number of Enemies" + enemyIndex + "\tand limit " + enemyLimit);
		// If the total number of enemies is reached
		if(enemies.Count == enemyLimit)
		{
			// ... exit the function.
			return;
		}

		//add enemy to list
		//enemies.Add (enemy);
		//enemyIndex++;

		
		// Find a random index between zero and one less than the number of spawn points
		int spawnPointIndex = -1;
		int attempts = 100;
		while (spawnPointIndex == -1 && attempts > 0) {
			spawnPointIndex = Random.Range (0, spawnPoints.Length - 1);
			foreach (GameObject e in enemies) {
				if (spawnPointIndex != -1 && (Vector3.Distance (e.transform.position, spawnPoints[spawnPointIndex].position) < minimumDistance)) {
					spawnPointIndex = -1;
				}
			}
			attempts = attempts - 1;
		}


		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Transform clone  = (Transform) Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		clone.tag = "Enemy";
		enemies.Add (clone.gameObject);
	}

	public void EnemyDied (GameObject e)
	{
		//decrease enemy count
	//	enemyIndex--;

		//remove enemy from list
		enemies.Remove (e);
	}
}
