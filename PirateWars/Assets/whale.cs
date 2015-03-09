using UnityEngine;
using System.Collections;

public class whale : MonoBehaviour {
	private GameObject player;	
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
	private string PATROL = "PATROL";
	private string CHASE = "CHASE";
	private string ATTACK = "ATTACK";
	private string state;
	
	//attack information
	private float firingRange = 150;
	private float minumuDistance = 25;
	private bool isNewAttackSequence;
	private Vector3 attackDestination;

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
}
