using UnityEngine;
using System.Collections;

public class CannonballCollision : MonoBehaviour {
	public GameObject explosion;
	public GameObject explosion2;
	public GameObject cargo;
	public int shipDamage;
	public int sailDamage;
	private bool dead;
	private float sinkTimer;
	
	// Use this for initialization
	void Start () {
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void checkDestroyEnemy(GameObject enemy, EnemyHealth health) {
		if (health.isDead ()) { 
				EnemyAI ai = enemy.GetComponent<EnemyAI> ();
				ai.setColliderLevel("DEAD");
				//Destroy (enemy);
				// ... move the enemy down by the sinkSpeed per second.

				EnemyManager em = GameObject.FindGameObjectWithTag ("EnemyManager").GetComponent<EnemyManager> ();
				em.EnemyDied(enemy);
				//Screen.showCursor = true;
				//Application.LoadLevel ("Game Over");

				Score score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
				score.addScore();
				Vector3 pos = new Vector3(gameObject.rigidbody.position.x, 31.4f, gameObject.rigidbody.position.z);
				Quaternion rot = Quaternion.Euler(90, 0, gameObject.rigidbody.rotation.z);
				Instantiate (cargo, pos, rot);
				//GameObject.FindGameObjectWithTag ("Enemy").transform.Translate (-Vector3.up * 0.7f * Time.deltaTime);
		}
	}

	private void enemyHit(Collider other, int amount) {
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
				health.hitDection(amount);

				//see if enemy should be killed
				checkDestroyEnemy(enemy, health);
				Destroy (gameObject);

			}
		}

	}

	void OnTriggerEnter(Collider other) 
	{

		if (other.tag == "EnemyShip") {
			//call explosion animation
			Instantiate (explosion, gameObject.transform.position, other.transform.rotation);

			//enemy hit for large damage
			enemyHit(other, shipDamage);

			//despawn cannonball
			Destroy (gameObject);

		} else if (other.tag == "EnemySail") {
			//call explosion animation
			Instantiate (explosion, gameObject.transform.position, other.transform.rotation);
			
			//enemy hit for large damage
			enemyHit(other, sailDamage);
			
			//despawn cannonball
			Destroy (gameObject);
		}
		else if (other.tag == "Terrain")
		{
			//call explosion animation for terrain
			Instantiate(explosion2, gameObject.transform.position, other.transform.rotation);
			//despawn cannonball
			Destroy (gameObject);
		}
		else if (other.tag == "Water")
		{
			//splash!

			//despawn cannonball
			Destroy (gameObject);
		}
	}
}