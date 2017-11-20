using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Animator anim;

	public float totlaHealth, currentHealth, expGranded,attackDamage,attackSpeed, moveSpeed;

	// Use this for initialization
	void Start () {

		currentHealth = totlaHealth;
		//anim.SetInteger ("Condition", 0);
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	public void GetHit(float damage){

		currentHealth -= damage;
		anim.SetInteger ("Condition", 2);
		StartCoroutine (RecoverFromHit ());
	}

	IEnumerator RecoverFromHit(){


		yield return new WaitForSeconds (0.5f);
		anim.SetInteger ("Condition", 0);
	}
}
