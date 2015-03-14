using UnityEngine;
using System.Collections;

public class whale : MonoBehaviour {
	GameObject player;	
	private GameObject ship;
	public string tag;
	
	//speeds
	public float rotationSpeed;
	public float chaseSpeed;
	public float patrolSpeed;
	public float attackSpeed;

	//way point information
	public Transform[] patrolWayPoints;				
	private int wayPointIndex;								
	private Transform wayPoint;
	private float distanceToDestination;
	
	//state information
	private string state;

	//attack information
	private float firingRange = 150;
	private float minumuDistance = 25;
	private bool isNewAttackSequence;
	private Vector3 attackDestination;
	PlayerHealth playerHealth;
	public float bounce;
	void Start () {
		Patrolling ();
	}
	void Update () {
		Patrolling ();
	}
	void Patrolling ()
	{
		if (distanceToDestination == 0) {
			wayPointIndex++;
			if (wayPointIndex == patrolWayPoints.Length) {
				wayPointIndex = 0;
			}
			else {
				wayPoint = patrolWayPoints[wayPointIndex];
			}
		}
		
		Move (transform.position, wayPoint.position, patrolSpeed);
	}
	
	void Move(Vector3 current, Vector3 destination, float speed) {
		if (destination - current != Vector3.zero) {
			Quaternion rotation = Quaternion.LookRotation(destination - current);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
		}
		
		distanceToDestination = Vector3.Distance (current, destination);
		transform.position = Vector3.MoveTowards(current, destination, speed * Time.deltaTime);
		//print ("current: " + current + "\t" + destination);
	}
	void OnTriggerEnter(Collider other) 
	{
		//ignores ships
		if (other.tag == "Player") {
			//print ("Collision");
			//player loses health, bounces off terrain
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent <PlayerHealth> ();
			
			float velocity = other.collider.rigidbody.velocity.x * other.collider.rigidbody.velocity.x
				+ other.collider.rigidbody.velocity.z * other.collider.rigidbody.velocity.z;
			
			if (velocity < 50) {
				other.collider.rigidbody.velocity = new Vector3 (-other.collider.rigidbody.velocity.x * 2.5f, 0, -other.collider.rigidbody.velocity.z * 2.5f);
				playerHealth.TakeDamage (5);
			} else {
				other.collider.rigidbody.velocity = new Vector3 ((-bounce) * other.collider.rigidbody.velocity.x, 0, (-bounce) * other.collider.rigidbody.velocity.z);
				playerHealth.TakeDamage (10);
			}
		}
	}
}
