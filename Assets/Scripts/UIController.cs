using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public static UIController instance;
	public Transform canvas;

	public Transform questInfo;
	public Transform questInfoContent;
	public Button questInfoAcceptButton;
	public Button questInfoCancelButton;
	public Button questInfoCompleteButton;

	// Quest Book Grid
	public Transform questBook;
	public Transform questBookContent;
	public Button questBookCancelButton;

	// Use this for initialization
	void Awake () {

		if (!instance) {
			instance = this;
			canvas = GameObject.Find ("UI").transform;
		}


		// Find the Quest Info UI Data

		questInfo = canvas.Find ("AllQuestsInfo");
		questInfoContent = questInfo.Find ("/Info/Viewport/Content");
		questInfoAcceptButton = questInfo.Find ("Info/Buttons/AcceptButton").GetComponent<Button> ();
		questInfoCancelButton = questInfo.Find ("/Info/Buttons/CancelButton").GetComponent<Button>();

		questInfoCancelButton.onClick.AddListener (() => {
			questInfo.gameObject.SetActive (false);
		});
	}







	
	// Update is called once per frame
	void Update () {
		
	}
}
