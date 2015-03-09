using UnityEngine;
using System.Collections;

public class Enemy1_AI : MonoBehaviour {
	
	//objects
	private GameObject player;	
	//private GameObject ship;
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
	private string PATROL = "PATROL";
	private string CHASE = "CHASE";
	private string ATTACK = "ATTACK";
	private string NOT_SET = "NOT_SET";
	private string state;
	
	//attack information
	private float firingRange = 150;
	private float minumuDistance = 25;
	private bool isNewAttackSequence;
	private Vector3 attackDestination;
	
	void Start () {
		//init player and enemy ship
		player = GameObject.FindGameObjectWithTag(Tags.playerShip);
		//ship = GameObject.FindGameObjectWithTag (tag);
		
		//set waypoint first waypoint and the distance to the waypoint is 0
		wayPointIndex = -1;
		distanceToDestination = 0;
		
		//start enemy state
		state = PATROL;
		
		//this is a new attack sequence because there is no previous attack
		isNewAttackSequence = true;
	}
	
	void Awake() {
		//player = GameObject.FindGameObjectWithTag(Tags.player);
	}
	
	public void setColliderLevel(string c) {
		if (c.Equals (ATTACK)) {
			state = ATTACK;
			//to prevent enemy stopping (jumping from attack and chase
		} else if (c.Equals (CHASE) && !state.Equals(ATTACK)) { 
			state = CHASE;
		} else if (c.Equals (PATROL)) {
			state = PATROL;
		}
		Update ();
	}
	
	// Update is called once per frame
	void Update () {
		//print (state);
		if (state.Equals (ATTACK)) {
			Attacking();
		} else if (state.Equals(CHASE)) {
			Chasing();
		} else if (state.Equals (PATROL)) {
			Patrolling ();
		} 
	}
	
	public bool userInSight() {
		//TODO: so that the opposite cannons do not fire
		return true;
	}
	
	public bool isAttackState() {
		return (state.Equals(ATTACK)) ? true : false;
	}
	void Maneuver() {
		//print ("travel to " + attackPosition +"\t" + attackPossibility + "\t" + transform.position + "\t" + player.transform.position);
		Move (transform.position, attackDestination, attackSpeed);
	}
	
	void ClearAttack() {
		isNewAttackSequence = true;
	}
	
	//TODO: decides which point to travel to
	void decideNextAttackPosition() {
		
		//not a new attack anymore (being decided now)
		isNewAttackSequence = false;
		
		//decide where to go
		Vector3 center = player.transform.position;
		Vector3 left = center;
		Vector3 right = center;
		Vector3 top = center;
		Vector3 bottom = center;
		
		//build travel diamond
		left.x = left.x - firingRange;
		right.x = right.x + firingRange;
		top.z = top.z + firingRange;
		bottom.z = bottom.z - firingRange;
		
		//set height in water to same
		left.y = transform.position.y;
		right.y = transform.position.y;
		top.y = transform.position.y;
		bottom.y = transform.position.y;
		
		//find which possible destination is nearest to user and enemy (assign left)
		Vector3 possible = Vector3.zero;
		float distance = firingRange * 2;
		
		//check left
		if (Vector3.Distance (transform.position,left) < distance && 
		    Vector3.Distance (transform.position,left) >= minumuDistance) {
			possible = left;
			distance = Vector3.Distance (transform.position, possible);
			// print ("Decide left: " + possible + "\t" + distance);
		}
		
		//check right
		if (Vector3.Distance (transform.position,right) < distance && 
		    Vector3.Distance (transform.position,right) >= minumuDistance) {
			possible = right;
			distance = Vector3.Distance (transform.position, possible);
			// print ("Decide right: " + possible + "\t" + distance);
		}
		
		//check top
		if (Vector3.Distance (transform.position,top) < distance && 
		    Vector3.Distance (transform.position,top) >= minumuDistance) {
			possible = top;
			distance = Vector3.Distance (transform.position, possible);
			// print ("Decide top: " + possible + "\t" + distance);
		}
		
		//check bottom
		if (Vector3.Distance (transform.position,bottom) < distance && 
		    Vector3.Distance (transform.position,bottom) >= minumuDistance) {
			possible = bottom;
			distance = Vector3.Distance (transform.position, possible);
			// print ("Decide bottom: " + possible + "\t" + distance);
		}
		
		//set attack position and destination
		attackDestination = possible;
		
	}
	
	void Attacking() {
		//this is the a new attack sequence
		if (isNewAttackSequence || distanceToDestination == 0) {
			decideNextAttackPosition ();
		} 
		Maneuver();
	}
	
	void Chasing() {
		ClearAttack ();
		Move (transform.position, player.transform.position, chaseSpeed);
	}
	
	void Patrolling ()
	{
		//state = PATROL;
		ClearAttack ();
		
		if (distanceToDestination == 0) {
			//print ("State is NONE");
			//state = "NONE";
			//int rand = Random.Range(0, patrolWayPoints.Length - 1);
			//while (rand == wayPointIndex) 
			//	rand = Random.Range(0, patrolWayPoints.Length - 1);
			//wayPointIndex = rand;
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
		//print ("Move: " + current + "\tto " + destination);
		if (destination - current != Vector3.zero) {
			Quaternion rotation = Quaternion.LookRotation(destination - current);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
		}
		
		distanceToDestination = Vector3.Distance (current, destination);
		transform.position = Vector3.MoveTowards(current, destination, speed * Time.deltaTime);
		//print ("current: " + current + "\t" + destination);
	}
}

