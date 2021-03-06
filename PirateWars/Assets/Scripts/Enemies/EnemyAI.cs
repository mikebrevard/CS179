﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	//objects
	private GameObject player;	

	//speeds
	public float rotationSpeed;
	public float chaseSpeed;
	public float patrolSpeed;
	public float attackSpeed;

	//way point information
	public Transform[] patrolWayPoints;				
	private int wayPointIndex;								
	private Transform wayPoint;

	//distance to destination (used for all movement)
	private float distanceToDestination;

	//state information
	private string PATROL = "PATROL";
	private string CHASE = "CHASE";
	private string ATTACK = "ATTACK";
	private string NOT_SET = "NOT_SET";
	private string DEAD = "DEAD";
	private string state;

	//attack information
	private float firingRange = 150;
	private float minumuDistance = 25;
	private bool isNewAttackSequence;
	private Vector3 attackDestination;

	private float deathTimer;

	void Start () {
		//init player and enemy ship
		player = GameObject.FindGameObjectWithTag(Tags.playerShip);
		
		//set waypoint first waypoint and the distance to the waypoint is 0
		wayPointIndex = -1;
		distanceToDestination = 0;

		//start enemy state (clones only not original)
		if (transform.tag.Equals ("Enemy"))
			state = PATROL;
		else
			state = NOT_SET;
		//print ("Enemy Created: " + transform.collider.GetInstanceID() + "\t" + transform.GetInstanceID() + "\t" + transform.gameObject.GetInstanceID());

		//this is a new attack sequence because there is no previous attack
		isNewAttackSequence = true;
	}

	void Awake() {
		//player = GameObject.FindGameObjectWithTag(Tags.player);
	}

	public void setColliderLevel(string c) {

		if (c.Equals (DEAD) || state == DEAD) {
				deathTimer = Time.time + 10;
				state = DEAD;
		} else if(c.Equals (NOT_SET)) {
				state = NOT_SET;
		} else if (c.Equals (ATTACK)) {
				state = ATTACK;
				//to prevent enemy stopping (jumping from attack and chase
		} else if (c.Equals (CHASE) && !state.Equals (ATTACK)) { 
				state = CHASE;
		} else if (c.Equals (PATROL)) {
				state = PATROL;
		} 
		Update ();
	}

	// Update is called once per frame
	void Update () {
		if (state.Equals (ATTACK)) {
			Attacking();
		} else if (state.Equals(CHASE)) {
			Chasing();
		} else if (state.Equals (PATROL)) {
			Patrolling ();
		} else if (state.Equals (DEAD)) {
			gameObject.transform.Translate (-Vector3.up * 2f * Time.deltaTime);
			gameObject.transform.Rotate (Vector3.forward * 4f * Time.deltaTime);
			if(Time.time > deathTimer)
				Destroy (gameObject);
		}
	}

	private bool ToBoolean(int value) {
		if (value == 0) {
			return false;
		} else {
			return true;
		}
	}

	public bool userInSight() {
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
		ClearAttack ();

		if (distanceToDestination == 0) {
			int rand = Random.Range(0, patrolWayPoints.Length - 1);
			while (rand == wayPointIndex) 
				rand = Random.Range(0, patrolWayPoints.Length - 1);
			wayPointIndex = rand;
			wayPoint = patrolWayPoints[wayPointIndex];
		}

		Move (transform.position, wayPoint.position, patrolSpeed);
	}
	
	void Move(Vector3 current, Vector3 destination, float speed) {
		//print ("Enemy " + transform.GetInstanceID() + "\tMove: " + current + "\tto " + destination);
		if (destination - current != Vector3.zero) {
			Quaternion rotation = Quaternion.LookRotation(destination - current);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
		}

		distanceToDestination = Vector3.Distance (current, destination);
		transform.position = Vector3.MoveTowards(current, destination, speed * Time.deltaTime);
		//print ("current: " + current + "\t" + destination);
	}
}
