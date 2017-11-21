using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	public delegate void AnimationEvent();
	public static event AnimationEvent OnSlashAnimationHit;


	void OnSlashAnimationHitEvent(){

		print ("event called");
		OnSlashAnimationHit ();

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
