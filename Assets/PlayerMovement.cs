﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed, velocity;
	Rigidbody rb;
	Animator anim;

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
















	void Move(){

		if (velocity == 0) {
			anim.SetInteger ("Condition", 0);
			return;
		} else {
			anim.SetInteger ("Condition", 1);
		}

		rb.MovePosition(transform.position + Vector3.right * velocity * movementSpeed * Time.deltaTime);
	}

	void SetVelocity(float dir){

		if (dir < 0)
			transform.LookAt (transform.position + Vector3.left);
		else if (dir > 0)
			transform.LookAt(transform.position + Vector3.right);
		velocity = dir;
	}

	void GetInput(){


		if (Input.GetKey (KeyCode.A)) {

			SetVelocity (-1);

		} else if (Input.GetKeyUp (KeyCode.A)) {

			SetVelocity (0);
		}

		if (Input.GetKey (KeyCode.D)) {

			SetVelocity (1);

		} else if (Input.GetKeyUp (KeyCode.D)) {

			SetVelocity (0);

		}
	}
}
