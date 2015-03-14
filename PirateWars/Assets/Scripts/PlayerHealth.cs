using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public float startingHealth = 100;
	public float maxHealth = 100;
	public float currentHealth;                                 
	public Slider healthBar;                                 
	bool isDead;                                                
	
	
	void Start ()
	{
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
	}
	
	
	public void TakeDamage (int amount)
	{	
		// Reduce the current health by the damage amount.
		currentHealth -= amount;
		
		// Set the health bar's value to the current health.
		healthBar.value = currentHealth;

		if(currentHealth <= 0 && !isDead)
		{
			// YOU ARE DEAD
			Death ();
		}
	}
	public void MaxHealth (int amount)
	{
		maxHealth += amount;
		currentHealth = maxHealth;
	}
	public void AddHealth (int amount)
	{
		currentHealth += amount;
		if(currentHealth > maxHealth)
			currentHealth = maxHealth;
		healthBar.value = currentHealth;
	}
	
	
	void Death ()
	{
		isDead = true;
		Screen.showCursor = true;
		Application.LoadLevel("Game Lost");
		//Application.LoadLevel("Game Main");
		// Turn off the movement and shooting scripts.
		//playerMovement.enabled = false;
		//playerShooting.enabled = false;
	}       
}