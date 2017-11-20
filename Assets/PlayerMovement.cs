using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[Header("Movement")]
	public float movementSpeed, velocity;
	Rigidbody rb;
	Animator anim;

	private bool isAttacking;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		GetInput ();
		Move ();

		
	}

	IEnumerator Attacking(){

		isAttacking = true;
		yield return new WaitForSeconds (1);
		isAttacking = false;
	}
















	void Move(){

		if (velocity == 0) {
		//anim.SetInteger ("Condition", 0);
			return;
		} else {
			if (!isAttacking) {
				anim.SetInteger ("Condition", 1);
				rb.MovePosition (transform.position + Vector3.right * velocity * movementSpeed * Time.deltaTime);
			}
		}


	}

	void SetVelocity(float dir){

		if (dir < 0)
			transform.LookAt (transform.position + Vector3.left);
		else if (dir > 0)
			transform.LookAt(transform.position + Vector3.right);
		velocity = dir;
	}

	void Attack(){

		if (isAttacking)
			return;
		StartCoroutine (Attacking());
		anim.SetInteger ("Condition", 2);

	}

	void GetInput(){

		if (Input.GetMouseButtonDown (0)) {

			Debug.Log ("attacking!");
			Attack ();
		}
		if (Input.GetKey (KeyCode.A)) {

			SetVelocity (-1);

		} else if (Input.GetKeyUp (KeyCode.A)) {
			anim.SetInteger ("Condition", 0);
			SetVelocity (0);
		}

		if (Input.GetKey (KeyCode.D)) {

			SetVelocity (1);

		} else if (Input.GetKeyUp (KeyCode.D)) {
			anim.SetInteger ("Condition", 0);

			SetVelocity (0);

		}
	}
}
