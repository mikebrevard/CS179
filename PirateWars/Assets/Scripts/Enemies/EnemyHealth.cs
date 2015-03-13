using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float rotationSpeed;
	private GameObject player;	
	private bool dead = false;
	public float currentHealth;   
	public GameObject healthBar;

	public bool isDead() {
		return dead;
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.player);
		healthBar.gameObject.renderer.material.color = Color.green;
	}

	public void hitDection(int amount) {
		print ("Hit Detected! " + currentHealth + "\t" + amount);
		currentHealth = currentHealth - amount;

		if (currentHealth <= 25) {
			healthBar.gameObject.renderer.material.color = Color.red;
		} else if (currentHealth <= 50) {
			healthBar.gameObject.renderer.material.color = Color.yellow;
		}

		//check if dead
		if (currentHealth <= 0) {
			dead = true;
			currentHealth = 0f;
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
		healthBar.gameObject.transform.localScale = new Vector3(currentHealth,10.0f,10.0f);
		if (player.transform.position - healthBar.gameObject.transform.position != Vector3.zero) {
			Quaternion rotation = Quaternion.LookRotation (player.transform.position - healthBar.gameObject.transform.position);
			healthBar.transform.rotation = Quaternion.Slerp (healthBar.transform.rotation, rotation, Time.deltaTime * rotationSpeed);
		}
	}
}
