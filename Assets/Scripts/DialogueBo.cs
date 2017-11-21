using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBo : MonoBehaviour {


	public static DialogueBo instance;

	private Transform dialogueBox;
	private Text dialogueBoxText;

	// Use this for initialization
	void Start () {

		if (instance == null) {

			instance = this;
		}

		dialogueBox = UIController.instance.canvas.Find ("QuestBox");
		dialogueBoxText = dialogueBox.Find ("QuestText").GetComponent<Text> ();
	}

	public void PrintDialogueBox(string text){

		dialogueBox.gameObject.SetActive (true);
		dialogueBoxText.text = text;
		InputManager.OnPressUp += CloseDialogueBoxCallback;
	}

	public void CloseDialogueBox(){

		dialogueBox.gameObject.SetActive (false);
	}

	public void CloseDialogueBoxCallback(){

		CloseDialogueBox ();
		InputManager.OnPressUp -= CloseDialogueBoxCallback;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
