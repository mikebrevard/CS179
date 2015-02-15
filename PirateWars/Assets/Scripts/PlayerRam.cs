using UnityEngine;
using System.Collections;

public class PlayerRam : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		
		if(other.tag == "EnemyShip") //and velocity exceeds X?
		{
			GameObject  enemy = GameObject.FindGameObjectWithTag ("HealthEnemyBar");
			EnemyHealth health = enemy.GetComponent<EnemyHealth>();
			health.hitDetection();
			if (health.isDead())
			{ 
				Destroy (GameObject.FindGameObjectWithTag ("Enemy"));
				Application.LoadLevel("Game Over");
			}
		}
	}
}
