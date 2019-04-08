using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
usimg UnityEngine.Networking;


public class Health : NetworkBehaviour
{
    public const int maxHealth  = 100;
	[SyncVar(hook = "OnChangeHealth")]public int currentHealth = maxHealth;
	public RectTransform healthbar;
	
	public void TakeDamage(int amount)
	{
		if(!isServer)
		{
			return;
		}
		currentHealth -= amount;
		if(currentHealth<=0)
		{
			currentHealth = 0;
			Debug.Log("Dead");
		}
	}
	void OnChangeHealth(int health) {
		
		healthbar.sizeDelta = new Vector2(health*2,healthbar.sizeDelta.y);
	
	}
		 
	
}
