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
				other.collider.rigidbody.velocity = new Vector3(-other.collider.rigidbody.velocity.x * 2.5f, 0, -other.collider.rigidbody.velocity.z * 2.5f) ;
				playerHealth.TakeDamage(5);
			}

			else
			{
				//print (other.collider.rigidbody.velocity.x);
				other.collider.rigidbody.velocity = new Vector3((-bounce)*other.collider.rigidbody.velocity.x, 0, (-bounce)*other.collider.rigidbody.velocity.z) ;
				playerHealth.TakeDamage(10);
			}



		} 
		else if(other.tag == "EnemyShip" || other.tag == "Enemy")
		{
			print ("Collision");
			//enemy = GameObject.FindGameObjectWithTag ("HealthEnemyBar");
			//enemyHealth = enemy.GetComponent<EnemyHealth> ();

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
				GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
				foreach (GameObject enemy in enemies) {
					if (enemy.transform.GetInstanceID().Equals(other.transform.parent.GetInstanceID())) {
						//put enemy into the fight if they are not already there
						EnemyAI ai = enemy.GetComponent<EnemyAI> ();
						if (!ai.isAttackState()) {
							ai.setColliderLevel("CHASE");
						}
						
						//enemy takes damage
						EnemyHealth health = enemy.GetComponent<EnemyHealth> ();
						health.hitDection(10);
						
						//see if enemy should be killed
						checkDestroyEnemy(enemy, health);
					}
				}
			}
		}
	}

	private void checkDestroyEnemy(GameObject enemy, EnemyHealth health) {
		if (health.isDead ()) { 
			Destroy (enemy);
			// ... move the enemy down by the sinkSpeed per second.
			//GameObject.FindGameObjectWithTag ("Enemy").transform.Translate (-Vector3.up * 0.7f * Time.deltaTime);
			EnemyManager em = GameObject.FindGameObjectWithTag ("EnemyManager").GetComponent<EnemyManager> ();
			em.EnemyDied(enemy);
			//Screen.showCursor = true;
			//Application.LoadLevel ("Game Over");
		}
	}
}
