using UnityEngine;
using System.Collections;

public class TerrainDestroyByContact : MonoBehaviour {

	GameObject player;
	GameObject enemy;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;

	public float bounce;
	void OnTriggerEnter(Collider other) 
	{
		//ignores ships
		if (other.tag == "Player") 
		{
			//player loses health, bounces off terrain
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent <PlayerHealth> ();

			float velocity = other.collider.rigidbody.velocity.x * other.collider.rigidbody.velocity.x
						   + other.collider.rigidbody.velocity.z * other.collider.rigidbody.velocity.z;

			if(velocity < 50)
			{
				other.collider.rigidbody.velocity = new Vector3(-other.collider.rigidbody.velocity.x * 2.0f, 0, -other.collider.rigidbody.velocity.z * 2.0f) ;
				playerHealth.TakeDamage(5);
			}

			else
			{
				other.collider.rigidbody.velocity = new Vector3((-bounce)*other.collider.rigidbody.velocity.x, 0, (-bounce)*other.collider.rigidbody.velocity.z) ;
				playerHealth.TakeDamage(10);
			}



		} 
		else if(other.tag == "Enemy")
		{
			enemy = GameObject.FindGameObjectWithTag ("HealthEnemyBar");
			enemyHealth = enemy.GetComponent<EnemyHealth> ();

			float velocity = other.collider.rigidbody.velocity.x * other.collider.rigidbody.velocity.x
				+ other.collider.rigidbody.velocity.z * other.collider.rigidbody.velocity.z;

			if(velocity < 50)
			{
				other.collider.rigidbody.velocity = new Vector3(-other.collider.rigidbody.velocity.x * 2.0f, 0, -other.collider.rigidbody.velocity.z * 2.0f) ;

			}
			
			else
			{
				other.collider.rigidbody.velocity = new Vector3((-bounce)*other.collider.rigidbody.velocity.x, 0, (-bounce)*other.collider.rigidbody.velocity.z) ;
				//enemyHealth.hitDetectionSmall();
			}
		}
	}
}
