using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float rotationSpeed;
	public Transform enemyShip;
	private GameObject player;	
	private bool dead = false;
	public float startingHealth = 100;                            // The amount of health the player starts the game with.
	public float currentHealth;   

	public bool isDead() {
		return dead;
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.player);
		gameObject.renderer.material.color = Color.green;
		currentHealth = startingHealth;
	}

	private void hitDection(int amount) {
		currentHealth = currentHealth - amount;

		if (currentHealth <= 25) {
			gameObject.renderer.material.color = Color.red;
		} else if (currentHealth <= 50) {
			gameObject.renderer.material.color = Color.yellow;
		}

		//check if dead
		if (currentHealth <= 0) {
			dead = true;
		}
	}

	public void hitDetectionSmall() {
		hitDection (10);
	}

	public void hitDetectionLarge() {
		hitDection (25);
	}

	// Update is called once per frame
	void Update () {
		if (player.transform.position - gameObject.transform.position != Vector3.zero) {
			Quaternion rotation = Quaternion.LookRotation (player.transform.position - gameObject.transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationSpeed);
		}
	}
}
