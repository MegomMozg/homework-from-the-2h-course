

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHP : MonoBehaviour
{

	[SerializeField] private float health = 100;
	public float currentHealth;

	private void Awake()
	{
		currentHealth = health;

	}
	public void Adjust(float value)
	{
		currentHealth += value;


	}
	private void FixedUpdate()
	{
		if (currentHealth <= 0)
		{
			gameObject.SetActive(false);
		}
	}
}
