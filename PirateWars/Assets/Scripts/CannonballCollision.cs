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
			Destroy (GameObject.FindGameObjectWithTag ("Enemy"));
			Application.LoadLevel ("Game Over");
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