using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBo : MonoBehaviour {


	public static DialogueBo instance;

	//public UIController UICon;

	//public Transform UIController;
	public Transform dialogueBox;
	private Text dialogueBoxText;

	// Use this for initialization
	void Start () {

//		UICon = GetComponent<UIController> ();
		if (instance == null) {

			instance = this;
		
		}
			dialogueBox = UIController.instance.canvas.Find ("QuestBox");
			dialogueBoxText = dialogueBox.transform.Find ("QuestText").GetComponent<Text> ();
		
	}

	public void PrintDialogueBox(string text){

		dialogueBox.gameObject.SetActive (true);
		dialogueBoxText.text = text;
		InputManager.OnPressUp += CloseDialogueBoxCallback;
		Debug.Log ("PrintDial called");
	}

	public void CloseDialogueBox(){
		WaitFor ();
		dialogueBox.gameObject.SetActive (false);
		Debug.Log ("closed dialoguebox called");
	}

	public void CloseDialogueBoxCallback(){

		Debug.Log ("callback called");
		CloseDialogueBox ();
		InputManager.OnPressUp -= CloseDialogueBoxCallback;
	}

	IEnumerator WaitFor(){

		yield return new WaitForSeconds (10);
	}
	

}
