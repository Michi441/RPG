using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {


	public GameObject playerTarget;

	// Use this for initialization
	void Start () {


		playerTarget = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (playerTarget.transform.position.x, transform.position.y, transform.position.z);
	}
}
