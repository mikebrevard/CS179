using UnityEngine;
using System.Collections;

public class Watertrail : MonoBehaviour {

	public Material firstMaterial;
	public Material secondMaterial;
	
	private float startTime;
	private float stopTime;
	private float destroy;
	
	//the time at which this came into existence
	private bool  isReallyOn;
	
	void Start (){
		isReallyOn = particleEmitter.emit;
		
		//this kind of emitter should always start off
		particleEmitter.emit = false;
		
		//get a random number between startTimeMin and Max
		startTime = (0.0f + Time.time);
		stopTime = (2.0f + Time.time);
		destroy = (3.0f + Time.time);
		
		
		//assign a random material
		renderer.material = Random.value > 0.5f ? firstMaterial : secondMaterial;
	}
	
	void FixedUpdate (){
		//is the start time passed? turn emit on
		if (Time.time > startTime)
		{
			particleEmitter.emit = true;
		}
		
		if (Time.time > stopTime)
		{
			particleEmitter.emit = false;
			if(Time.time > destroy)
				Destroy (gameObject);
		}
	}
}
