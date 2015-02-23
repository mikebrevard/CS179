using UnityEngine;
using System.Collections;

public class PlayerRam : MonoBehaviour {

	GameObject player;
	PlayerHealth playerHealth;

	void OnTriggerEnter(Collider other) 
	{
		
		if(other.tag == "EnemyShip") //and velocity exceeds X?
		{
			GameObject  enemy = GameObject.FindGameObjectWithTag ("HealthEnemyBar");
			EnemyHealth health = enemy.GetComponent<EnemyHealth>();
			health.hitDetectionLarge();
			if (health.isDead())
			{ 
				Destroy (GameObject.FindGameObjectWithTag ("Enemy"));
				Application.LoadLevel("Game Over");
			}

			player = GameObject.FindGameObjectWithTag ("Player");
			//TODO: add back in health
			playerHealth = player.GetComponent <PlayerHealth> ();
			playerHealth.TakeDamage(5);
		}
	}
}
