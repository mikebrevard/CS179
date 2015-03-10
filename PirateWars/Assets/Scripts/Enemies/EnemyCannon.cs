using UnityEngine;
using System.Collections;

public class EnemyCannon : MonoBehaviour {

	public GameObject cannonball;
	public float rateOfFire;
	//float fireDelay;
	public float speed;
	public EnemyAI enemyAIscript;
	private float fire;

	// Use this for initializationf
	void Start () {

	}
	
	void Update()
	{
	
		if (enemyAIscript.isAttackState() && enemyAIscript.userInSight() && Time.time > fire) {
			fire = Time.time + rateOfFire;
			GameObject clone = (GameObject)Instantiate (cannonball, transform.position, transform.rotation);
			clone.rigidbody.velocity = transform.TransformDirection (new Vector3(0,0,speed));
			//Physics.IgnoreCollision (clone.collider, enemyShip.transform.collider);
			audio.Play();
		}
	}
}
