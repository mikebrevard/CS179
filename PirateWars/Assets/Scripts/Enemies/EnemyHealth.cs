﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float rotationSpeed;
	public Transform enemyShip;
	private GameObject player;	
	private bool dead = false;

	public bool isDead() {
		return dead;
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.player);
		gameObject.renderer.material.color = Color.green;
	}

	public void hitDetection() {
		gameObject.renderer.material.color = Color.red;
		dead = true;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R))
		{
			gameObject.renderer.material.color = Color.red;
		}
		if(Input.GetKeyDown(KeyCode.G))
		{
			gameObject.renderer.material.color = Color.green;
		}

		if (player.transform.position - gameObject.transform.position != Vector3.zero) {
			Quaternion rotation = Quaternion.LookRotation (player.transform.position - gameObject.transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationSpeed);
		}
	}
}
