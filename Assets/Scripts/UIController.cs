using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	public static UIController instance;
	public Transform canvas;

	// Use this for initialization
	void Awake () {

		if (!instance) {
			instance = this;
			canvas = GameObject.Find ("Canvas").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
