using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Animator anim;

	public float totlaHealth, currentHealth, expGranded,attackDamage,attackSpeed, moveSpeed;

	// Use this for initialization
	void Start () {


		//anim.SetInteger ("Condition", 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			Debug.Log ("hit enemy");
			GetHit ();
		}
		
	}

	public void GetHit(){


		anim.SetInteger ("Condition", 2);
		StartCoroutine (RecoverFromHit ());
	}

	IEnumerator RecoverFromHit(){


		yield return new WaitForSeconds (0.5f);
		anim.SetInteger ("Condition", 0);
	}
}
