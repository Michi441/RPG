using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

	public string[] dialogues;
	public int dialoguesIndex = 0;

	// Use this for initialization
	void Start () {
		
	}
	


	public void ShowDialogue(){

		if (dialoguesIndex > (dialogues.Length - 1)) {
			
			DialogueBo.instance.CloseDialogueBox ();

			dialoguesIndex = (dialogues.Length - 1);
			dialoguesIndex = -1;
		} else {
			
			//print (name + ": " + dialogues [dialoguesIndex]);
			DialogueBo.instance.PrintDialogueBox (name + ": " + dialogues [dialoguesIndex]);

		}
	}

	IEnumerator Wait(){

		yield return new WaitForSeconds (5f);

	}
}
