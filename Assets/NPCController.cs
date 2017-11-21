using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

	public string[] dialogues;
	public int dialoguesIndex = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowDialogue(){

		if (dialoguesIndex > (dialogues.Length - 1)) {
			dialoguesIndex = (dialogues.Length - 1);
		}
			print (name + ": " + dialogues [dialoguesIndex]);
		
	}
}
