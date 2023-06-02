using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitValue : MonoBehaviour

{
	public float baseDamage = 1;
	public float bonus;
	public float damage;

	private void Update()
	{
		damage = baseDamage + bonus;
	}

}
