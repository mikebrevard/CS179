using UnityEngine;
using System.Collections;

public class CannonballCollision : MonoBehaviour {
	public GameObject explosion;
	public GameObject explosion2;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void checkDestroyEnemy(EnemyHealth health) {
		if (health.isDead ()) { 
			//Destroy (GameObject.FindGameObjectWithTag ("Enemy"));
			// ... move the enemy down by the sinkSpeed per second.
			GameObject.FindGameObjectWithTag ("Enemy").transform.Translate (-Vector3.up * 0.7f * Time.deltaTime);
			EnemyManager em = GameObject.FindGameObjectWithTag ("EnemyManager").GetComponent<EnemyManager> ();
			em.EnemyDied();
			//Screen.showCursor = true;
			//Application.LoadLevel ("Game Over");
		}
	}

	void OnTriggerEnter(Collider other) 
	{

		if (other.tag == "EnemyShip") {
			//call explosion animation
			Instantiate (explosion, gameObject.transform.position, other.transform.rotation);
			GameObject enemy = GameObject.FindGameObjectWithTag ("HealthEnemyBar");
			EnemyHealth health = enemy.GetComponent<EnemyHealth> ();
			health.hitDetectionLarge ();
			print ("Ship hit!");
			checkDestroyEnemy(health);

			//despawn cannonball
			Destroy (gameObject);

		} else if (other.tag == "EnemySail") {
			//call explosion animation
			Instantiate (explosion, gameObject.transform.position, other.transform.rotation);
			GameObject enemy = GameObject.FindGameObjectWithTag ("HealthEnemyBar");
			EnemyHealth health = enemy.GetComponent<EnemyHealth> ();
			health.hitDetectionSmall ();

			checkDestroyEnemy(health);
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