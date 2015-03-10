using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

	private GameObject player;	
	public EnemyAI ai;

	private string PATROL = "PATROL";
	private string CHASE = "CHASE";
	private string ATTACK = "ATTACK";
	
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.playerShip);
	}
	
	
	void Awake() {

	}

	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
	}
	
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject == player) {
			ai.setColliderLevel(CHASE);
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) {
			ai.setColliderLevel(PATROL);
		}
	}

}
