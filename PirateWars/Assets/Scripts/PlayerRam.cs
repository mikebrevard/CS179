using UnityEngine;
using System.Collections;

public class PlayerRam : MonoBehaviour {

	GameObject player;
	PlayerHealth playerHealth;
	public GameObject cargo;

	void OnTriggerEnter(Collider other) 
	{
		
		if(other.tag == "EnemyShip") //and velocity exceeds X?
		{
			//GameObject  enemy = GameObject.FindGameObjectWithTag ("HealthEnemyBar");
			//EnemyHealth health = enemy.GetComponent<EnemyHealth> ();
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
					health.hitDection(25);
					
					//see if enemy should be killed
					checkDestroyEnemy(enemy, health);
				}
			}
			//if (health.isDead())
			//{ 
			//	Destroy (GameObject.FindGameObjectWithTag ("Enemy"));
			//	Application.LoadLevel("Game Over");
			//}

			player = GameObject.FindGameObjectWithTag ("Player");
			//TODO: add back in health
			playerHealth = player.GetComponent <PlayerHealth> ();
			playerHealth.TakeDamage(5);
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
			Score score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
			score.addScore();

			Vector3 pos = new Vector3(gameObject.rigidbody.position.x, 31.4f, gameObject.rigidbody.position.z);
			Quaternion rot = Quaternion.Euler(90, 0, gameObject.rigidbody.rotation.z);
			Instantiate (cargo, pos, rot);
		}
	}
}
